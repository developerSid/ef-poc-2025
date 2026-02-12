using Microsoft.Extensions.DependencyInjection;
using PayerEdi.Pharmacy.Services;

namespace PayerEdi.Pharmacy.Extensions;

public static class Startup
{
    public static IServiceCollection AddPharmacyServices(this IServiceCollection services)
    {
        services.AddScoped<IHipaa837pIngestionService, Hipaa837pIngestionService>();
        return services;
    }
}