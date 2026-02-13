using EdiFabric;
using EdiFabric.Templates.Hipaa5010;
using Microsoft.Extensions.DependencyInjection;
using PayerEdi.Ingestion.Extensions;
using PayerEdi.Pharmacy.Data.Extensions;
using PayerEdi.Pharmacy.Extensions;
using PayerEdi.Pharmacy.Services;
using Serilog;
using DataStartup = PayerEdi.Pharmacy.Data.Extensions.Startup;

namespace PayerEdi.EdiFabric.Console;

internal static class Program
{
    static async Task<int> Main(string[] _)
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.Console()
            .CreateLogger();

        try
        {
            Log.Information("Starting EDI ingestion console application.");

            var serialKey = Environment.GetEnvironmentVariable("EDIFABRIC_SERIAL_KEY", EnvironmentVariableTarget.Machine);

            if (string.IsNullOrWhiteSpace(serialKey))
            {
                Log.Error("Set EDIFABRIC_SERIAL_KEY to your EdiFabric serial key.");
                return 1;
            }

            SerialKey.Set(serialKey, false);
            Log.Information("EdiFabric serial key is configured.");

            var connectionString = Environment.GetEnvironmentVariable("HIPAA_DB_CONNECTION", EnvironmentVariableTarget.Machine)
                ?? DataStartup.BuildSqlExpressConnectionString("PayerEdiPharmacy");

            IServiceCollection services = new ServiceCollection();
            services.AddIngestionServices();
            services.AddHipaa837pDbContext(_ => connectionString);
            services.AddPharmacyServices();

            await using var provider = services.BuildServiceProvider(new ServiceProviderOptions
            {
                ValidateScopes = true,
                ValidateOnBuild = true
            });

            Log.Information("Running HIPAA 837P database migration.");
            await provider.MigrateHipaa837pAsync();

            const string SamplePath = "837p-sample.edi";

            if (!File.Exists(SamplePath))
            {
                Log.Error("Sample file not found at {SamplePath}", SamplePath);
                return 1;
            }

            await using var scope = provider.CreateAsyncScope();
            var ingestion = scope.ServiceProvider.GetRequiredService<IHipaa837pIngestionService>();

            Log.Information("Ingesting sample file {SamplePath}.", SamplePath);
            await using var stream = File.OpenRead(SamplePath);
            var transactions = await ingestion.IngestAsync(stream);

            if (!transactions.Any(x => x.GetType() == typeof(TS837P)))
            {
                Log.Error("Sample file did not contain TS837P data.");
                return 1;
            }

            Log.Information("Sample file {SamplePath} ingested with TS837P data.", SamplePath);
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
}