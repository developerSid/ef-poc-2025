namespace PayerEdi.Pharmacy.Tests.Infrastructure;

/// <summary>
/// Confirms the fixture-provisioned SQL database is available and fully migrated.
/// </summary>
public sealed class SqlExpressDatabaseTests(DbFixture fixture) : DbTestBase(fixture)
{
    /// <summary>
    /// Verifies connectivity and asserts there are no pending EF migrations at test start.
    /// </summary>
    [Fact]
    public async Task DatabaseIsReachableWithNoPendingMigrations()
    {
        var context = GetService<Hipaa837pDbContext>();

        Assert.True(await context.Database.CanConnectAsync(CancellationToken));

        var pending = await context.Database.GetPendingMigrationsAsync(CancellationToken);
        Assert.Empty(pending);
    }
}
