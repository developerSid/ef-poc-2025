using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml;
using System.Xml.Serialization;
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
using PayerEDI.Data.Database.Tables;
using PayerEDI.Data.Models.Claims;
using PayerEDI.Data.Services;
using PayerEDI.Processor.Console.Command;
using Serilog;

static string SerializeXml<T>(T value)
{
    var serializer = new XmlSerializer(value is null ? typeof(T) : value.GetType());
    var settings = new XmlWriterSettings { Indent = true, OmitXmlDeclaration = true };

    using var stringWriter = new StringWriter();
    using var xmlWriter = XmlWriter.Create(stringWriter, settings);
    serializer.Serialize(xmlWriter, value);

    return stringWriter.ToString();
}

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
            var jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            };

            logger.LogInformation("Claims found in {file}", ediFile);
            foreach ((EdiMessage, HealthCareClaim) claim in claims) // These files can be batches, how to handle something that doesn't fit the HealthCareClaim hierarchy at some point?
            {
                switch (claim)
                {
                    case (TS837P edi, ProfessionalCareClaim pro)
                        when logger.IsEnabled(LogLevel.Debug):
                        logger.LogDebug(
                            "TS837P:\n{ProClaim:l}",
                            JsonSerializer.Serialize(pro, jsonOptions)
                        );
                        var proDoc = new DocumentTable
                        {
                            EdiMessageType = "TS837P",
                            Xml = SerializeXml(edi),
                        };
                        logger.LogDebug("DocumentTable: {Document:l}", proDoc);
                        break;
                    case (TS837D edi, DentalCareClaim dental) when logger.IsEnabled(LogLevel.Debug):
                        logger.LogDebug(
                            "TS837D:\n{DentalClaim:l}",
                            JsonSerializer.Serialize(dental, jsonOptions)
                        );
                        var dentalDoc = new DocumentTable
                        {
                            EdiMessageType = "TS837D",
                            Xml = SerializeXml(edi),
                        };
                        logger.LogDebug("DocumentTable: {Document:l}", dentalDoc);
                        break;
                    default:
                        logger.LogWarning("Unknown claim: {Claim}", claim);
                        break;
                }

                switch (claim)
                {
                    case (TS837P edi, ProfessionalCareClaim _)
                        when logger.IsEnabled(LogLevel.Trace):
                        logger.LogTrace("TS837P XML:\n{ProClaimXml:l}", SerializeXml(edi));
                        break;
                    case (TS837D edi, DentalCareClaim _) when logger.IsEnabled(LogLevel.Trace):
                        logger.LogTrace("TS837D XML:\n{DentalClaimXml:l}", SerializeXml(edi));
                        break;
                }
            }
        }
        else
        {
            logger.LogError("Edi file not found: {EdiFile}", ediFile);
        }
    });
