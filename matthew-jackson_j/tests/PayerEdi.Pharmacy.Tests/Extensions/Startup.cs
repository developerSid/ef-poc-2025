using PayerEdi.Ingestion.Extensions;
using PayerEdi.Ingestion.IO;
using PayerEdi.Pharmacy.Data.Extensions;
using PayerEdi.Pharmacy.Extensions;
using Microsoft.Extensions.Configuration;

namespace PayerEdi.Pharmacy.Tests.Extensions;

/// <summary>
/// Test DI helpers for wiring ingestion and data services against test fixtures.
/// </summary>
public static class Startup
{
    /// <summary>
    /// Registers fixture-backed services required by integration tests.
    /// </summary>
    public static void AddTestServices(this IServiceCollection services, DbFixture fixture)
    {
        var configuration = BuildConfiguration();
        services.AddSingleton(fixture);

        services.AddHipaa837pDbContext(sp =>
        {
            var dbFixture = sp.GetRequiredService<DbFixture>();
            return dbFixture.ConnectionString;
        });
        services.AddLogging();

        services.AddIngestionServices(configuration);
        services.AddPharmacyServices();
        services.AddScoped<TestFileService>();
        services.AddScoped<IFileService>(sp => sp.GetRequiredService<TestFileService>());
    }

    /// <summary>
    /// Builds a validating test service provider.
    /// </summary>
    public static IServiceProvider BuildTestServiceProvider(this IServiceCollection services, DbFixture fixture)
    {
        services.AddTestServices(fixture);

        return services.BuildServiceProvider(new ServiceProviderOptions
        {
            ValidateScopes = true,
            ValidateOnBuild = true
        });
    }

    /// <summary>
    /// Deletes test database state when a connection string is available.
    /// </summary>
    public static async Task EnsureTestDatabaseDeletedAsync(this IServiceProvider provider, string connectionString, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(connectionString))
            return;

        await provider.EnsureHipaa837pDeletedAsync(cancellationToken);
    }

    /// <summary>
    /// Applies test database migrations.
    /// </summary>
    public static async Task MigrateTestDatabaseAsync(this IServiceProvider provider, CancellationToken cancellationToken = default)
    {
        await provider.MigrateHipaa837pAsync(cancellationToken);
    }

    private static IConfiguration BuildConfiguration()
    {
        return new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
            .Build();
    }
}
