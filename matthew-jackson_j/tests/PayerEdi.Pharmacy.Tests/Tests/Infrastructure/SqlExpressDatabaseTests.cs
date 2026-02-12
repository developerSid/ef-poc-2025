namespace PayerEdi.Pharmacy.Tests.Tests.Infrastructure;

public sealed class SqlExpressDatabaseTests : DbTestBase
{
    public SqlExpressDatabaseTests(DbFixture fixture) : base(fixture)
    {
    }

    [Fact]
    public async Task DatabaseIsReachableWithNoPendingMigrations()
    {
        var context = GetService<Hipaa837pDbContext>();

        Assert.True(await context.Database.CanConnectAsync(CancellationToken));

        var pending = await context.Database.GetPendingMigrationsAsync(CancellationToken);
        Assert.Empty(pending);
    }
}
