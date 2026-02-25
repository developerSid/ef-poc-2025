using EdiFabric;
using EdiFabric.Templates.Hipaa5010;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.Console()
            .CreateLogger();

        try
        {
            Log.Information("Starting EDI ingestion console application.");

            var configuration = BuildConfiguration();
            var serialKey = configuration["EdiFabric:SerialKey"];

            if (string.IsNullOrWhiteSpace(serialKey))
            {
                Log.Error("Set 'EdiFabric:SerialKey' in appsettings.json.");
                return 1;
            }

            SerialKey.Set(serialKey, false);
            Log.Information("EdiFabric serial key is configured.");

            var connectionString = configuration.GetConnectionString("HipaaDb");
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                Log.Error("Set 'ConnectionStrings:HipaaDb' in appsettings.json.");
                return 1;
            }

            var samplePath = configuration["Ingestion:SampleFilePath"];
            if (string.IsNullOrWhiteSpace(samplePath))
            {
                Log.Error("Set 'Ingestion:SampleFilePath' in appsettings.json.");
                return 1;
            }

            IServiceCollection services = new ServiceCollection();
            services.AddIngestionServices(configuration);
            services.AddHipaa837pDbContext(_ => connectionString);
            services.AddPharmacyServices();
            services.AddScoped<IFileService, ConsoleFileService>();

            await using var provider = services.BuildServiceProvider(new ServiceProviderOptions
            {
                ValidateScopes = true,
                ValidateOnBuild = true
            });

            Log.Information("Running HIPAA 837P database migration.");
            await provider.MigrateHipaa837pAsync();

            await using var scope = provider.CreateAsyncScope();
            var ingestion = scope.ServiceProvider.GetRequiredService<IHipaa837pIngestionService>();
            var fileService = scope.ServiceProvider.GetRequiredService<IFileService>();
            var fullSamplePath = Path.GetFullPath(samplePath);
            var bucket = Path.GetDirectoryName(fullSamplePath)
                ?? throw new InvalidOperationException($"Unable to resolve sample directory from '{samplePath}'.");
            var key = Path.GetFileName(fullSamplePath);

            Log.Information("Ingesting sample file {SamplePath}.", samplePath);
            var keys = await fileService.ListAsync(bucket);
            if (!keys.Contains(key, StringComparer.OrdinalIgnoreCase))
            {
                Log.Error("Sample file '{SamplePath}' was not found in bucket '{Bucket}'.", samplePath, bucket);
                return 1;
            }

            var transactions = await ingestion.IngestAsync(bucket, key);

            if (!transactions.Any(x => x.GetType() == typeof(TS837P)))
            {
                Log.Error("Sample file did not contain TS837P data.");
                return 1;
            }

            Log.Information("Sample file {SamplePath} ingested with TS837P data.", samplePath);
            return 0;
        }
        catch (Exception exception)
        {
            Log.Fatal(exception, "Unhandled exception while processing ingestion.");
            return 1;
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }

    private static IConfiguration BuildConfiguration()
    {
        return new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
            .Build();
    }
}
