using Microsoft.Extensions.DependencyInjection;
using PayerEdi.Ingestion.Validation.x12;

namespace PayerEdi.Ingestion.Validation.x12._837p;

/// <summary>
/// Registers TS837P SNIP validator cache wiring.
/// </summary>
public static class Startup
{
    /// <summary>
    /// Adds TS837P SNIP 1-4 validators into the shared X12 validator cache registration pipeline.
    /// </summary>
    public static IServiceCollection AddTS837PSnipValidation(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddX12ValidatorCache();
        services.AddX12ValidatorRegistration(cache => cache.AddTS837PSnipValidators());

        return services;
    }
}
