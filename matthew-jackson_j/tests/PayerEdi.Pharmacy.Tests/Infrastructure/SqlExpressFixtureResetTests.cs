namespace PayerEdi.Pharmacy.Tests.Infrastructure;

[Collection("db")]
public sealed class SqlExpressFixtureResetTests(DbFixture fixture)
{
    [Fact]
    public async Task ResetAsyncCreatesANewDatabase()
    {
        string firstDatabase;

        using (var scope = fixture.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<Hipaa837pDbContext>();
            firstDatabase = context.Database.GetDbConnection().Database;
        }

        await fixture.ResetAsync();

        using var newScope = fixture.CreateScope();
        var newContext = newScope.ServiceProvider.GetRequiredService<Hipaa837pDbContext>();
        var secondDatabase = newContext.Database.GetDbConnection().Database;

        Assert.NotEqual(firstDatabase, secondDatabase);
    }
}