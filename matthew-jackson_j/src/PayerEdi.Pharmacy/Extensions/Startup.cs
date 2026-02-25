using Microsoft.Extensions.Configuration;
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

    /// <summary>
    /// Adds pre-save SNIP validation to ingestion using configured options.
    /// </summary>
    public static IServiceCollection AddSnipValidationPreSaveHook(this IServiceCollection services, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(configuration);

        services.AddOptions<SnipValidationOptions>()
            .Bind(configuration.GetSection(SnipValidationOptions.SectionName));
        services.AddScoped<IIngestionPreSaveHook, X12SnipValidationPreSaveHook>();

        return services;
    }
}
