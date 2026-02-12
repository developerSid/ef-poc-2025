using Microsoft.Data.SqlClient;
using PayerEdi.Pharmacy.Data.Hipaa837p;

namespace PayerEdi.Pharmacy.Data.Extensions;

public static class Startup
{
    public static string GenerateDatabaseName() => $"PayerEdiPharmacy_{Guid.NewGuid():N}";

    public static string BuildSqlExpressConnectionString(string databaseName, string? dataSource = null)
    {
        dataSource ??= @".\SQLEXPRESS";

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

    public static async Task EnsureHipaa837pDeletedAsync(this IServiceProvider provider, CancellationToken cancellationToken = default)
    {
        using var scope = provider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<Hipaa837pDbContext>();
        await context.Database.EnsureDeletedAsync(cancellationToken);
    }

    public static async Task MigrateHipaa837pAsync(this IServiceProvider provider, CancellationToken cancellationToken = default)
    {
        using var scope = provider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<Hipaa837pDbContext>();
        await context.Database.MigrateAsync(cancellationToken);
    }
}
