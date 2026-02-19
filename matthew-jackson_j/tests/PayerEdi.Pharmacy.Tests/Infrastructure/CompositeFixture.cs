namespace PayerEdi.Pharmacy.Tests.Infrastructure;

/// <summary>
/// Combines DB and ingestion fixtures for tests that require both environments.
/// </summary>
public sealed class CompositeFixture : IAsyncLifetime
{
    public CompositeFixture()
    {
        Db = new DbFixture();
        Ingestion = new IngestionFixture();
    }

    public DbFixture Db { get; }
    public IngestionFixture Ingestion { get; }

    /// <inheritdoc />
    public async ValueTask InitializeAsync()
    {
        await Db.InitializeAsync();
        await Ingestion.InitializeAsync();
    }

    /// <inheritdoc />
    public async ValueTask DisposeAsync()
    {
        await Ingestion.DisposeAsync();
        await Db.DisposeAsync();
    }

    /// <summary>
    /// Creates a scoped service provider for database-backed tests.
    /// </summary>
    public IServiceScope CreateDbScope() => Db.CreateScope();
    /// <summary>
    /// Creates a scoped service provider for ingestion-only tests.
    /// </summary>
    public IServiceScope CreateIngestionScope() => Ingestion.CreateScope();
}
