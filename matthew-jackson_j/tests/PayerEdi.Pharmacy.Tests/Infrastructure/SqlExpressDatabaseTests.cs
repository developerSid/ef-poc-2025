namespace PayerEdi.Pharmacy.Tests.Infrastructure;

public sealed class SqlExpressDatabaseTests(DbFixture fixture) : DbTestBase(fixture)
{

    [Fact]
    public async Task DatabaseIsReachableWithNoPendingMigrations()
    {
        var context = GetService<Hipaa837pDbContext>();

        Assert.True(await context.Database.CanConnectAsync(CancellationToken));

        var pending = await context.Database.GetPendingMigrationsAsync(CancellationToken);
        Assert.Empty(pending);
    }
}