using Microsoft.Data.SqlClient;
using PayerEdi.Pharmacy.Data.Hipaa837p;

namespace PayerEdi.Pharmacy.Data.Extensions;

/// <summary>
/// Data-layer DI and SQL Server helper extensions.
/// </summary>
public static class Startup
{
    /// <summary>
    /// Generates a unique SQL database name for isolated test or local runs.
    /// </summary>
    public static string GenerateDatabaseName() => $"PayerEdiPharmacy_{Guid.NewGuid():N}";

    /// <summary>
    /// Builds a SQL Server Express connection string with sane local defaults.
    /// </summary>
    public static string BuildSqlExpressConnectionString(string databaseName, string dataSource)
    {
        var builder = new SqlConnectionStringBuilder
        {
            DataSource = dataSource,
            InitialCatalog = databaseName,
            IntegratedSecurity = true,
            TrustServerCertificate = true,
            MultipleActiveResultSets = true
        };

        return builder.ToString();
    }

    /// <summary>
    /// Registers <see cref="Hipaa837pDbContext"/> with a caller-provided connection string factory.
    /// </summary>
    public static IServiceCollection AddHipaa837pDbContext(
        this IServiceCollection services,
        Func<IServiceProvider, string> connectionStringFactory)
    {
        services.AddDbContext<Hipaa837pDbContext>((sp, opt) =>
        {
            var connectionString = connectionStringFactory(sp);
            opt.UseSqlServer(connectionString);
        });

        return services;
    }

    /// <summary>
    /// Deletes the HIPAA schema database for the configured context.
    /// </summary>
    public static async Task EnsureHipaa837pDeletedAsync(this IServiceProvider provider, CancellationToken cancellationToken = default)
    {
        using var scope = provider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<Hipaa837pDbContext>();
        await context.Database.EnsureDeletedAsync(cancellationToken);
    }

    /// <summary>
    /// Applies pending migrations for the configured HIPAA schema database.
    /// </summary>
    public static async Task MigrateHipaa837pAsync(this IServiceProvider provider, CancellationToken cancellationToken = default)
    {
        using var scope = provider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<Hipaa837pDbContext>();
        await context.Database.MigrateAsync(cancellationToken);
    }
}
