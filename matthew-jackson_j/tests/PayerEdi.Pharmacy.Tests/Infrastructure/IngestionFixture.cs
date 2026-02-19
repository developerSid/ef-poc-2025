using PayerEdi.Ingestion.Extensions;

namespace PayerEdi.Pharmacy.Tests.Infrastructure;

/// <summary>
/// Builds a lightweight DI container for ingestion-only tests.
/// </summary>
public sealed class IngestionFixture : IAsyncLifetime
{
    private IServiceProvider _provider = default!;

    /// <summary>
    /// Creates a test scope for resolving ingestion services.
    /// </summary>
    public IServiceScope CreateScope() => _provider.CreateScope();

    /// <inheritdoc />
    public ValueTask InitializeAsync()
    {
        IServiceCollection services = new ServiceCollection();
        services.AddIngestionServices();

        _provider = services.BuildServiceProvider(new ServiceProviderOptions
        {
            ValidateScopes = true,
            ValidateOnBuild = true
        });

        return ValueTask.CompletedTask;
    }

    /// <inheritdoc />
    public async ValueTask DisposeAsync()
    {
        await _provider.DisposeProviderAsync();
    }
}
