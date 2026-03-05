namespace PayerEdi.Pharmacy.Tests.Infrastructure;

[Collection("db")]
/// <summary>
/// Base class for tests that require a fresh migrated DB scope.
/// </summary>
public abstract class DbTestBase(DbFixture fixture) : IAsyncLifetime
{
    private IServiceScope _scope = default!;

    /// <inheritdoc />
    public async ValueTask InitializeAsync()
    {
        await fixture.ResetAsync();
        _scope = fixture.CreateScope();
    }

    /// <inheritdoc />
    public ValueTask DisposeAsync()
    {
        _scope.Dispose();
        GC.SuppressFinalize(this);
        return ValueTask.CompletedTask;
    }

    /// <summary>
    /// Resolves a service from the current test scope.
    /// </summary>
    protected TService GetService<TService>() where TService : notnull => _scope.ServiceProvider.GetRequiredService<TService>();

    /// <summary>
    /// Current test cancellation token provided by xUnit.
    /// </summary>
    protected static CancellationToken CancellationToken => TestContext.Current.CancellationToken;
}
