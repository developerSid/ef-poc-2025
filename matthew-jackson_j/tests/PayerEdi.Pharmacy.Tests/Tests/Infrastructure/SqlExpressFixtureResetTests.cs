namespace PayerEdi.Pharmacy.Tests.Tests.Infrastructure;

[Collection("db")]
public sealed class SqlExpressFixtureResetTests
{
    private readonly DbFixture _fixture;

    public SqlExpressFixtureResetTests(DbFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task ResetAsyncCreatesANewDatabase()
    {
        string firstDatabase;

        using (var scope = _fixture.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<Hipaa837pDbContext>();
            firstDatabase = context.Database.GetDbConnection().Database;
        }

        await _fixture.ResetAsync();

        using var newScope = _fixture.CreateScope();
        var newContext = newScope.ServiceProvider.GetRequiredService<Hipaa837pDbContext>();
        var secondDatabase = newContext.Database.GetDbConnection().Database;

        Assert.NotEqual(firstDatabase, secondDatabase);
    }
}
