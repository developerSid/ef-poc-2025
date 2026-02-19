using Microsoft.Data.SqlClient;
using PayerEdi.Pharmacy.Tests.Extensions;
using DataStartup = PayerEdi.Pharmacy.Data.Extensions.Startup;

namespace PayerEdi.Pharmacy.Tests.Infrastructure;

/// <summary>
/// Creates and resets an isolated SQL database for integration tests.
/// </summary>
public sealed class DbFixture : IAsyncLifetime
{
    private const string ConnectionEnvVarName = "HIPAA_DB_CONNECTION";
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
        var configuredConnection = Environment.GetEnvironmentVariable(ConnectionEnvVarName, EnvironmentVariableTarget.Process);
        configuredConnection ??= Environment.GetEnvironmentVariable(ConnectionEnvVarName, EnvironmentVariableTarget.Machine);

        if (string.IsNullOrWhiteSpace(configuredConnection))
            return DataStartup.BuildSqlExpressConnectionString(databaseName);

        var builder = new SqlConnectionStringBuilder(configuredConnection)
        {
            InitialCatalog = databaseName,
            TrustServerCertificate = true
        };

        return builder.ConnectionString;
    }
}
