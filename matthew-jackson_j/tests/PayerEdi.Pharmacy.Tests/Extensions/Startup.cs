using PayerEdi.Ingestion.Extensions;
using PayerEdi.Pharmacy.Data.Extensions;
using PayerEdi.Pharmacy.Extensions;

namespace PayerEdi.Pharmacy.Tests.Extensions;

public static class Startup
{
    public static void AddTestServices(this IServiceCollection services, DbFixture fixture)
    {
        services.AddSingleton(fixture);

        services.AddHipaa837pDbContext(sp =>
        {
            var dbFixture = sp.GetRequiredService<DbFixture>();
            return dbFixture.ConnectionString;
        });

        services.AddIngestionServices();
        services.AddPharmacyServices();
    }

    public static IServiceProvider BuildTestServiceProvider(this IServiceCollection services, DbFixture fixture)
    {
        services.AddTestServices(fixture);

        return services.BuildServiceProvider(new ServiceProviderOptions
        {
            ValidateScopes = true,
            ValidateOnBuild = true
        });
    }

    public static async Task EnsureTestDatabaseDeletedAsync(this IServiceProvider provider, string connectionString, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(connectionString))
            return;

        await provider.EnsureHipaa837pDeletedAsync(cancellationToken);
    }

    public static async Task MigrateTestDatabaseAsync(this IServiceProvider provider, CancellationToken cancellationToken = default)
    {
        await provider.MigrateHipaa837pAsync(cancellationToken);
    }
}
