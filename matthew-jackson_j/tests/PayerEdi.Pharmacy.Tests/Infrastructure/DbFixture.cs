using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using PayerEdi.Pharmacy.Tests.Extensions;
using DataStartup = PayerEdi.Pharmacy.Data.Extensions.Startup;

namespace PayerEdi.Pharmacy.Tests.Infrastructure;

/// <summary>
/// Creates and resets an isolated SQL database for integration tests.
/// </summary>
public sealed class DbFixture : IAsyncLifetime
{
    private IServiceProvider _provider = default!;
    private string _databaseName = string.Empty;
    private string _connectionString = string.Empty;

    public DbFixture()
    {
    }

    /// <summary>
    /// Creates a scoped provider for test service resolution.
    /// </summary>
    public IServiceScope CreateScope() => _provider.CreateScope();
    /// <summary>
    /// Active connection string for the current isolated database.
    /// </summary>
    public string ConnectionString => _connectionString;

    /// <inheritdoc />
    public async ValueTask InitializeAsync()
    {
        _provider = new ServiceCollection().BuildTestServiceProvider(this);

        await ResetAsync();
    }

    /// <summary>
    /// Recreates the backing database and reapplies migrations.
    /// </summary>
    public async ValueTask ResetAsync()
    {
        await _provider.EnsureTestDatabaseDeletedAsync(_connectionString);

        _databaseName = DataStartup.GenerateDatabaseName();
        _connectionString = BuildConnectionString(_databaseName);

        await _provider.MigrateTestDatabaseAsync();
    }

    /// <inheritdoc />
    public async ValueTask DisposeAsync()
    {
        await _provider.EnsureTestDatabaseDeletedAsync(_connectionString);
        await _provider.DisposeProviderAsync();
    }

    private static string BuildConnectionString(string databaseName)
    {
        var configuration = BuildConfiguration();
        var configuredConnection = configuration.GetConnectionString("HipaaDb");

        if (string.IsNullOrWhiteSpace(configuredConnection))
        {
            configuredConnection = configuration.GetConnectionString("SqlServerFallbackDb");
            if (string.IsNullOrWhiteSpace(configuredConnection))
                throw new InvalidOperationException("Configuration key 'ConnectionStrings:SqlServerFallbackDb' is required.");
        }

        var builder = new SqlConnectionStringBuilder(configuredConnection)
        {
            InitialCatalog = databaseName,
            TrustServerCertificate = true
        };

        return builder.ConnectionString;
    }

    private static IConfiguration BuildConfiguration()
    {
        return new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
            .Build();
    }
}
