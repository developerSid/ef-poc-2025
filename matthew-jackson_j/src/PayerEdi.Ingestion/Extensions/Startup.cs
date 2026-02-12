using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace PayerEdi.Ingestion.Extensions;

public static class Startup
{
    public static void AddIngestionServices(this IServiceCollection services)
    {
        if (!services.Any(d => d.ServiceType == typeof(IEdiReaderSniffer)))
            services.AddSingleton<IEdiReaderSniffer, EdiReaderSniffer>();

        if (!services.Any(d => d.ServiceType == typeof(IEdiReaderFactory)))
            services.AddSingleton<IEdiReaderFactory, EdiReaderFactory>();

        if (!services.Any(d => d.ServiceType == typeof(IEdiTokenProvider)))
            services.AddSingleton<IEdiTokenProvider, EdiTokenProvider>();

        if (!services.Any(d => d.ServiceType == typeof(Func<Stream, IEdiReader>)))
        {
            services.AddSingleton<Func<Stream, IEdiReader>>(sp => stream =>
                sp.GetRequiredService<IEdiReaderFactory>().Create(stream));
        }
    }
}
