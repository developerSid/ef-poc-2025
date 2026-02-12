using PayerEdi.Pharmacy.Tests.Extensions;
using DataStartup = PayerEdi.Pharmacy.Data.Extensions.Startup;

namespace PayerEdi.Pharmacy.Tests.Infrastructure;

public sealed class DbFixture : IAsyncLifetime
{
    private IServiceProvider _provider = default!;
    private string _databaseName = string.Empty;
    private string _connectionString = string.Empty;

    public DbFixture()
    {
    }

    public IServiceScope CreateScope() => _provider.CreateScope();
    public string ConnectionString => _connectionString;

    public async ValueTask InitializeAsync()
    {
        _provider = new ServiceCollection().BuildTestServiceProvider(this);

        await ResetAsync();
    }

    public async ValueTask ResetAsync()
    {
        await _provider.EnsureTestDatabaseDeletedAsync(_connectionString);

        _databaseName = DataStartup.GenerateDatabaseName();
        _connectionString = DataStartup.BuildSqlExpressConnectionString(_databaseName);

        await _provider.MigrateTestDatabaseAsync();
    }

    public async ValueTask DisposeAsync()
    {
        await _provider.EnsureTestDatabaseDeletedAsync(_connectionString);
        await _provider.DisposeProviderAsync();
    }
}
