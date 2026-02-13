using PayerEdi.Ingestion.Extensions;

namespace PayerEdi.Pharmacy.Tests.Infrastructure;

public sealed class IngestionFixture : IAsyncLifetime
{
    private IServiceProvider _provider = default!;

    public IServiceScope CreateScope() => _provider.CreateScope();

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

    public async ValueTask DisposeAsync()
    {
        await _provider.DisposeProviderAsync();
    }
}