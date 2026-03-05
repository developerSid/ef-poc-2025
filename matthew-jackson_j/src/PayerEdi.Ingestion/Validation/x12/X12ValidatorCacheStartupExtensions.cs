using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace PayerEdi.Ingestion.Validation.x12;

/// <summary>
/// DI registration helpers for X12 validator cache creation and composable registrations.
/// </summary>
public static class X12ValidatorCacheStartupExtensions
{
    /// <summary>
    /// Adds a singleton <see cref="IX12ValidatorCache"/> and applies all registered cache actions.
    /// </summary>
    public static IServiceCollection AddX12ValidatorCache(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.TryAddSingleton<IX12ValidatorCache>(sp =>
        {
            var cache = new X12ValidatorCache();

            foreach (var register in sp.GetServices<Action<IX12ValidatorCache>>())
                register(cache);

            return cache;
        });

        return services;
    }

    /// <summary>
    /// Adds a cache registration action that will run when the singleton cache is created.
    /// </summary>
    public static IServiceCollection AddX12ValidatorRegistration(this IServiceCollection services, Action<IX12ValidatorCache> register)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(register);

        services.AddSingleton(register);
        return services;
    }
}
