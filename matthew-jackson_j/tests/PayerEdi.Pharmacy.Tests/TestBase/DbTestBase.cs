namespace PayerEdi.Pharmacy.Tests.TestBase;

[Collection("db")]
public abstract class DbTestBase : IAsyncLifetime
{
    protected DbFixture Fixture { get; }
    private IServiceScope _scope = default!;

    protected DbTestBase(DbFixture fixture) => Fixture = fixture;

    public async ValueTask InitializeAsync()
    {
        await Fixture.ResetAsync();
        _scope = Fixture.CreateScope();
    }

    public async ValueTask DisposeAsync()
    {
        _scope.Dispose();
        await ValueTask.CompletedTask;
    }

    protected TService GetService<TService>() where TService : notnull => _scope.ServiceProvider.GetRequiredService<TService>();

    protected CancellationToken CancellationToken => TestContext.Current.CancellationToken;
}
