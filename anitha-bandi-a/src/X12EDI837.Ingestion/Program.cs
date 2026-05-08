using Amazon.S3;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using X12EDI837.Ingestion.Infrastructure;
using X12EDI837.Ingestion.Infrastructure.FileSource;
using X12EDI837.Ingestion.Services;

namespace X12EDI837.Ingestion;

internal sealed class Program
{
    // -------------------------------------------------------------------------
    // Entry point
    // -------------------------------------------------------------------------
    private static async Task<int> Main(string[] args)
    {
        try
        {
            // 1. Build and configure the generic host
            IHost host = BuildHost(args);

            // 2. Set EdiFabric licence key BEFORE resolving any EDI services
            SetEdiFabricKey(host);

            // 3. Run the ingestion pipeline inside a DI scope.
            //    AppDbContext is Scoped, so it must be resolved within a scope.
            using IServiceScope scope = host.Services.CreateScope();
            EdiIngestionService ingestion =
                scope.ServiceProvider.GetRequiredService<EdiIngestionService>();

            await ingestion.RunAsync();

            return 0;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"[FATAL] Unhandled exception: {ex.Message}");
            Console.Error.WriteLine(ex.ToString());
            return 1;
        }
    }

    // -------------------------------------------------------------------------
    // Host builder — all DI registrations live here
    // -------------------------------------------------------------------------
    private static IHost BuildHost(string[] args)
    {
        try
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    // ── Options 
                    services.Configure<FileSourceOptions>(
                        context.Configuration.GetSection(FileSourceOptions.SectionName));

                    // ── Database 
                    string? connStr = context.Configuration
                        .GetSection("Database:ConnectionStrings")["HIPAA_5010_837P"];

                    services.AddDbContext<AppDbContext>(opts =>
                        opts.UseSqlServer(connStr));

                    // ── EDI Parser 
                    services.AddTransient<IEdiParser, EdiParserService>();

                    // ── Ingestion orchestrator 
                    services.AddTransient<EdiIngestionService>();

                    // ── File Source (local vs S3 — driven by config) 
                    RegisterFileSource(context.Configuration, services);
                })
                .Build();
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Failed to build host: {ex.Message}", ex);
        }
    }

    // -------------------------------------------------------------------------
    // Register either LocalFileSource or S3FileSource based on appsettings
    // -------------------------------------------------------------------------
    private static void RegisterFileSource(
        IConfiguration configuration,
        IServiceCollection services)
    {
        try
        {
            string provider =
                configuration[$"{FileSourceOptions.SectionName}:Provider"] ?? "local";

            if (provider.Equals("s3", StringComparison.OrdinalIgnoreCase))
            {
                // Wire real (or moto-mocked) S3 client
                services.AddSingleton<IAmazonS3>(sp =>
                {
                    FileSourceOptions opts =
                        sp.GetRequiredService<IOptions<FileSourceOptions>>().Value;

                    AmazonS3Config cfg = new AmazonS3Config
                    {
                        ServiceURL     = opts.S3ServiceUrl,
                        ForcePathStyle = true,
                    };

                    return new AmazonS3Client("test", "test", cfg);
                });

                services.AddSingleton<IFileSource, S3FileSource>();
            }
            else
            {
                services.AddScoped<IFileSource, LocalFileSource>();
            }
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Failed to register file source: {ex.Message}", ex);
        }
    }

    // -------------------------------------------------------------------------
    // Set EdiFabric serial key from configuration
    // -------------------------------------------------------------------------
    private static void SetEdiFabricKey(IHost host)
    {
        try
        {
            string? token = host.Services
                .GetRequiredService<IConfiguration>()["EDI:Token"];

            if (!string.IsNullOrWhiteSpace(token))
                EdiFabric.SerialKey.Set(token);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Failed to set EdiFabric key: {ex.Message}", ex);
        }
    }
}