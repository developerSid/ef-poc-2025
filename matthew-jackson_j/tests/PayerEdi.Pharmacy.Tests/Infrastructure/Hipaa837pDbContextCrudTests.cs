using EdiFabric.Templates.Hipaa5010;

namespace PayerEdi.Pharmacy.Tests.Infrastructure;

public sealed class Hipaa837pDbContextCrudTests(DbFixture fixture) : DbTestBase(fixture)
{

    [Fact]
    public async Task CanSaveAndLoadTransaction()
    {
        var context = GetService<Hipaa837pDbContext>();

        var transaction = new TS837P();
        context.TS837P.Add(transaction);
        await context.SaveChangesAsync(CancellationToken);

        var reloaded = await context.TS837P.AsNoTracking().SingleAsync(CancellationToken);
        Assert.True(reloaded.Id > 0);
    }
}