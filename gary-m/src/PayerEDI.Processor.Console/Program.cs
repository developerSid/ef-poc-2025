using System.Text.Json;
using System.Text.Json.Serialization;
using CommandLine;
using EdiFabric.Core.Model.Edi;
using EdiFabric.Templates.Hipaa5010;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PayerEDI.Data;
using PayerEDI.Data.Database;
using PayerEDI.Data.Database.Repositories;
using PayerEDI.Data.Helpers;
using PayerEDI.Data.Models.Claims;
using PayerEDI.Data.Services;
using PayerEDI.Processor.Console.Command;
using Serilog;

await Parser
    .Default.ParseArguments<CliOptions>(args)
    .WithNotParsed(errors =>
    {
        foreach (var error in errors)
        {
            Console.WriteLine(error);
        }
    })
    .WithParsedAsync(async options =>
    {
        var ediFile = Path.GetFullPath(options.EdiFile, Directory.GetCurrentDirectory());
        using var app = Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration(
                (hostingContext, config) =>
                {
                    config
                        .AddJsonFile(
                            "appsettings.all.example.json",
                            optional: true,
                            reloadOnChange: false
                        )
                        .AddJsonFile(
                            $"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.example.json",
                            optional: true,
                            reloadOnChange: false
                        );
                    config.AddEnvironmentVariables("EDI_PROCESSOR_");
                }
            )
            .ConfigureServices(
                (context, services) =>
                {
                    services.AddSingleton<IEdiProcessor, EdiFabricEdiProcessor>();

                    if (!options.Save)
                    {
                        return;
                    }

                    var connectionString =
                        context.Configuration.GetConnectionString("Default")
                        ?? throw new InvalidOperationException(
                            "The default database connection string is required when --save is enabled. Set EDI_PROCESSOR_CONNECTIONSTRINGS__DEFAULT."
                        );

                    // AddDbContext registers the EF Core context as scoped by default so each processing
                    // scope gets one unit-of-work context; DbContext is not thread-safe and should not
                    // be shared across concurrent work or retained for the application's lifetime.
                    services.AddDbContext<PayerEdiDbContext>(dbOptions =>
                        dbOptions.UseSqlServer(connectionString)
                    );
                    // These services consume the scoped EF Core DbContext, so they must also be scoped.
                    services.AddScoped<IDocumentTableRepository, DocumentTableRepository>();
                    services.AddScoped<IPatientRepository, PatientRepository>();
                    services.AddScoped<IPersistenceService, PersistenceService>();
                }
            )
            .UseSerilog(
                (context, _, configuration) =>
                {
                    configuration
                        .ReadFrom.Configuration(context.Configuration)
                        .Enrich.FromLogContext();
                }
            )
            .Build();

        var logger = app.Services.GetRequiredService<ILogger<Program>>();
        var ediFabricKey =
            app.Services.GetRequiredService<IConfiguration>()["Key:Edifabric"]
            ?? throw new InvalidOperationException("EDI Fabric Key is required");
        var tokenLoadedVia = EdiFabricHelper.ConfigureEdiFabric(ediFabricKey);

        logger.LogDebug("EdiFabric token configuration: {TokenLoadedVia}", tokenLoadedVia);

        if (File.Exists(ediFile))
        {
            await using var ediStream = File.OpenRead(ediFile);
            var claims = app.Services.GetRequiredService<IEdiProcessor>().ProcessEdi(ediStream);
            var jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            };

            logger.LogInformation("Claims found in {file}", ediFile);

            foreach ((EdiMessage, HealthCareClaim) claim in claims) // These files can be batches, how to handle something that doesn't fit the HealthCareClaim hierarchy at some point?
            {
                if (options.Save)
                {
                    // Use one scope per claim so its scoped DbContext and change tracker are disposed
                    // promptly instead of retaining every entity from the entire EDI file.
                    await using var scope = app.Services.CreateAsyncScope();
                    var persistenceService =
                        scope.ServiceProvider.GetRequiredService<IPersistenceService>();

                    switch (claim)
                    {
                        case (TS837P edi, ProfessionalCareClaim pro):
                            await persistenceService.Save(edi, pro);
                            break;
                        case (TS837D edi, DentalCareClaim dental):
                            await persistenceService.Save(edi, dental);
                            break;
                        default:
                            logger.LogWarning("Unknown claim: {Claim}", claim);
                            break;
                    }
                }

                switch (claim.Item2)
                {
                    case ProfessionalCareClaim pro:

                        if (logger.IsEnabled(LogLevel.Debug))
                        {
                            logger.LogDebug(
                                "TS837P:\n{ProClaim:l}",
                                JsonSerializer.Serialize(pro, jsonOptions)
                            );
                        }

                        break;
                    case DentalCareClaim dental:
                        if (logger.IsEnabled(LogLevel.Debug))
                        {
                            logger.LogDebug(
                                "TS837D:\n{DentalClaim:l}",
                                JsonSerializer.Serialize(dental, jsonOptions)
                            );
                        }

                        break;
                    default:
                        logger.LogWarning("Unknown claim: {Claim}", claim);
                        break;
                }

                switch (claim)
                {
                    case (TS837P edi, ProfessionalCareClaim _)
                        when logger.IsEnabled(LogLevel.Trace):
                        logger.LogTrace("TS837P XML:\n{ProClaimXml:l}", edi.ToXml());
                        break;
                    case (TS837D edi, DentalCareClaim _) when logger.IsEnabled(LogLevel.Trace):
                        logger.LogTrace("TS837D XML:\n{DentalClaimXml:l}", edi.ToXml());
                        break;
                }
            }
        }
        else
        {
            logger.LogError("Edi file not found: {EdiFile}", ediFile);
        }
    });
