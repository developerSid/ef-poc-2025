namespace PayerEdi.Pharmacy.Tests.Infrastructure;

[Collection("db")]
public abstract class DbTestBase(DbFixture fixture) : IAsyncLifetime
{
    private IServiceScope _scope = default!;

    public async ValueTask InitializeAsync()
    {
        await fixture.ResetAsync();
        _scope = fixture.CreateScope();
    }

    public ValueTask DisposeAsync()
    {
        _scope.Dispose();
        GC.SuppressFinalize(this);
        return ValueTask.CompletedTask;
    }

    protected TService GetService<TService>() where TService : notnull => _scope.ServiceProvider.GetRequiredService<TService>();

    protected static CancellationToken CancellationToken => TestContext.Current.CancellationToken;
}