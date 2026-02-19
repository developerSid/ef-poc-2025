using Microsoft.Extensions.DependencyInjection;
using PayerEdi.Pharmacy.Services;

namespace PayerEdi.Pharmacy.Extensions;

/// <summary>
/// Registers pharmacy-domain services.
/// </summary>
public static class Startup
{
    /// <summary>
    /// Adds ingestion workflow services for HIPAA 837P processing.
    /// </summary>
    public static IServiceCollection AddPharmacyServices(this IServiceCollection services)
    {
        services.AddScoped<IHipaa837pIngestionService, Hipaa837pIngestionService>();
        return services;
    }
}
