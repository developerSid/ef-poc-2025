namespace PayerEdi.Pharmacy.Extensions;

public static class ServiceProviderExtensions
{
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
