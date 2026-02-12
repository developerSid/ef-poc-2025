namespace PayerEdi.Pharmacy.Tests.Infrastructure;

public sealed class CompositeFixture : IAsyncLifetime
{
    public CompositeFixture()
    {
        Db = new DbFixture();
        Ingestion = new IngestionFixture();
    }

    public DbFixture Db { get; }
    public IngestionFixture Ingestion { get; }

    public async ValueTask InitializeAsync()
    {
        await Db.InitializeAsync();
        await Ingestion.InitializeAsync();
    }

    public async ValueTask DisposeAsync()
    {
        await Ingestion.DisposeAsync();
        await Db.DisposeAsync();
    }

    public IServiceScope CreateDbScope() => Db.CreateScope();
    public IServiceScope CreateIngestionScope() => Ingestion.CreateScope();
}
