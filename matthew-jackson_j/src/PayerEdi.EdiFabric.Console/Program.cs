using EdiFabric;
using EdiFabric.Templates.Hipaa5010;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PayerEdi.Ingestion.Extensions;
using PayerEdi.Ingestion.IO;
using PayerEdi.Pharmacy.Data.Extensions;
using PayerEdi.Pharmacy.Extensions;
using PayerEdi.Pharmacy.Services;
using Serilog;

namespace PayerEdi.EdiFabric.Console;

/// <summary>
/// Console entry point for local 837P sample ingestion into SQL Server Express.
/// </summary>
internal static class Program
{
    /// <summary>
    /// Runs migration + sample ingestion workflow and returns process exit code.
    /// </summary>
    static async Task<int> Main(string[] _)
    {
        var configuration = BuildConfiguration();
        var serilogLogger = CreateSerilogLogger(configuration);
        using var loggerFactory = new Serilog.Extensions.Logging.SerilogLoggerFactory(serilogLogger, dispose: false);
        var logger = loggerFactory.CreateLogger("PayerEdi.EdiFabric.Console");

        try
        {
            logger.LogInformation("Starting EDI ingestion console application.");
            logger.LogInformation("Loaded configuration from base directory '{BaseDirectory}'.", AppContext.BaseDirectory);

            var serialKey = configuration["EdiFabric:SerialKey"];

            if (string.IsNullOrWhiteSpace(serialKey))
            {
                logger.LogError("Set 'EdiFabric:SerialKey' in appsettings.json.");
                return 1;
            }

            SerialKey.Set(serialKey, false);
            logger.LogInformation("EdiFabric serial key is configured.");

            var connectionString = configuration.GetConnectionString("HipaaDb");
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                logger.LogError("Set 'ConnectionStrings:HipaaDb' in appsettings.json.");
                return 1;
            }

            var samplePath = configuration["Ingestion:SampleFilePath"];
            if (string.IsNullOrWhiteSpace(samplePath))
            {
                logger.LogError("Set 'Ingestion:SampleFilePath' in appsettings.json.");
                return 1;
            }
            logger.LogInformation("Resolved ingestion sample path '{SamplePath}'.", samplePath);

            IServiceCollection services = new ServiceCollection();
            services.AddLogging(logging =>
            {
                logging.ClearProviders();
                logging.AddSerilog(serilogLogger, dispose: false);
            });
            services.AddIngestionServices(configuration);
            services.AddHipaa837pDbContext(_ => connectionString);
            services.AddPharmacyServices();
            services.AddScoped<IFileService, ConsoleFileService>();
            logger.LogInformation("Service registrations complete. Building service provider.");

            await using var provider = services.BuildServiceProvider(new ServiceProviderOptions
            {
                ValidateScopes = true,
                ValidateOnBuild = true
            });
            logger.LogInformation("Service provider built successfully.");

            logger.LogInformation("Running HIPAA 837P database migration.");
            await provider.MigrateHipaa837pAsync();
            logger.LogInformation("Database migration completed.");

            await using var scope = provider.CreateAsyncScope();
            logger.LogInformation("Created scoped service provider for ingestion.");
            var ingestion = scope.ServiceProvider.GetRequiredService<IHipaa837pIngestionService>();
            var fileService = scope.ServiceProvider.GetRequiredService<IFileService>();
            var fullSamplePath = Path.GetFullPath(samplePath);
            var bucket = Path.GetDirectoryName(fullSamplePath)
                ?? throw new InvalidOperationException($"Unable to resolve sample directory from '{samplePath}'.");
            var key = Path.GetFileName(fullSamplePath);
            logger.LogInformation("Resolved ingestion source to bucket '{Bucket}' and key '{Key}'.", bucket, key);

            logger.LogInformation("Ingesting sample file {SamplePath}.", samplePath);
            var keys = await fileService.ListAsync(bucket);
            logger.LogInformation("Found {KeyCount} file(s) in bucket '{Bucket}'.", keys.Count, bucket);
            if (!keys.Contains(key, StringComparer.OrdinalIgnoreCase))
            {
                logger.LogError("Sample file '{SamplePath}' was not found in bucket '{Bucket}'.", samplePath, bucket);
                return 1;
            }

            var transactions = await ingestion.IngestAsync(bucket, key);

            if (!transactions.Any(x => x.GetType() == typeof(TS837P)))
            {
                logger.LogError("Sample file did not contain TS837P data.");
                return 1;
            }

            logger.LogInformation("Sample file {SamplePath} ingested with TS837P data.", samplePath);
            return 0;
        }
        catch (Exception exception)
        {
            logger.LogCritical(exception, "Unhandled exception while processing ingestion.");
            return 1;
        }
    }

    private static IConfiguration BuildConfiguration()
    {
        return new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
            .Build();
    }

    private static Serilog.ILogger CreateSerilogLogger(IConfiguration configuration)
    {
        return new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .WriteTo.Console()
            .CreateLogger();
    }
}
