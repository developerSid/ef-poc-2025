namespace PayerEdi.Pharmacy.Extensions;

/// <summary>
/// Helpers for deterministic service provider disposal across sync/async containers.
/// </summary>
public static class ServiceProviderExtensions
{
    /// <summary>
    /// Disposes the provider using async disposal when available, otherwise sync disposal.
    /// </summary>
    public static async ValueTask DisposeProviderAsync(this IServiceProvider provider)
    {
        if (provider is IAsyncDisposable asyncDisposable)
        {
            await asyncDisposable.DisposeAsync();
        }
        else if (provider is IDisposable disposable)
        {
            disposable.Dispose();
        }
    }
}
