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

Parser
    .Default.ParseArguments<CliOptions>(args)
    .WithNotParsed(errors =>
    {
        foreach (var error in errors)
        {
            Console.WriteLine(error);
        }
    })
    .WithParsed(options =>
    {
        var ediFile = Path.GetFullPath(options.EdiFile, Directory.GetCurrentDirectory());
        var app = Host.CreateDefaultBuilder(args)
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
                    var connectionString =
                        context.Configuration.GetConnectionString("Default")
                        ?? throw new InvalidOperationException(
                            "The default database connection string is required. Set EDI_PROCESSOR_CONNECTIONSTRINGS__DEFAULT."
                        );

                    services.AddDbContext<PayerEdiDbContext>(dbOptions =>
                        dbOptions.UseSqlServer(connectionString)
                    );
                    services.AddSingleton<EdiProcessor>();
                    services.AddScoped<DocumentTableRepository>();
                    services.AddScoped<PatientRepository>();
                    services.AddScoped<PersistenceService>();
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
            using var ediStream = File.OpenRead(ediFile);
            var claims = app.Services.GetRequiredService<EdiProcessor>().ProcessEdi(ediStream);
            var jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            };

            logger.LogInformation("Claims found in {file}", ediFile);
            using var scope = app.Services.CreateScope();
            var persistenceService = scope.ServiceProvider.GetRequiredService<PersistenceService>();

            foreach ((EdiMessage, HealthCareClaim) claim in claims) // These files can be batches, how to handle something that doesn't fit the HealthCareClaim hierarchy at some point?
            {
                switch (claim)
                {
                    case (TS837P edi, ProfessionalCareClaim pro):
                        persistenceService.Save(edi).GetAwaiter().GetResult();
                        persistenceService.Save(pro).GetAwaiter().GetResult();
                        if (logger.IsEnabled(LogLevel.Debug))
                        {
                            logger.LogDebug(
                                "TS837P:\n{ProClaim:l}",
                                JsonSerializer.Serialize(pro, jsonOptions)
                            );
                        }
                        break;
                    case (TS837D edi, DentalCareClaim dental):
                        persistenceService.Save(edi).GetAwaiter().GetResult();
                        persistenceService.Save(dental).GetAwaiter().GetResult();
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
