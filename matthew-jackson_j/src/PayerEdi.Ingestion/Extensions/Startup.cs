using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using PayerEdi.Ingestion.Reader;
using PayerEdi.Ingestion.S3;
using PayerEdi.Ingestion.Sniffing;
using PayerEdi.Ingestion.Tokens;

namespace PayerEdi.Ingestion.Extensions;

/// <summary>
/// Registers ingestion-layer services and optional S3 integration components.
/// </summary>
public static class Startup
{
    /// <summary>
    /// Adds core ingestion services used for stream sniffing, reader creation, and token setup.
    /// </summary>
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

    /// <summary>
    /// Adds the S3 consumer and applies optional configuration overrides.
    /// </summary>
    public static void AddS3Consumer(this IServiceCollection services, Action<S3ConsumerOptions>? configure = null)
    {
        if (!services.Any(d => d.ServiceType == typeof(IS3Consumer)))
        {
            if (configure is null)
            {
                services.Configure<S3ConsumerOptions>(_ => { });
            }
            else
            {
                services.Configure(configure);
            }

            services.AddSingleton<IS3Consumer, S3Consumer>();
        }
    }
}
