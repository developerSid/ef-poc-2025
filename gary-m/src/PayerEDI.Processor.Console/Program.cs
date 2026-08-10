using CommandLine;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PayerEDI.Data;
using PayerEDI.Data.Data;
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

            logger.LogInformation("Claims found in {file}", ediFile);
            foreach (HealthCareClaim claim in claims) // These files can be batches of claims so need to process each one
            {
                switch (claim) // FIXME: can be this be made exhaustive at some point
                {
                    case ProfessionalCareClaim professionalCareClaim:
                        logger.LogInformation("Profession Claim: {claim}", professionalCareClaim);
                        break;
                    case DentalCareClaim dentalClaim:
                        logger.LogInformation("Dental Claim: {claim}", dentalClaim);
                        break;
                    default:
                        logger.LogError("Unhandled Claim: {claim}", claim);
                        break;
                }
            }
        }
        else
        {
            logger.LogError("Edi file not found: {EdiFile}", ediFile);
        }
    });
