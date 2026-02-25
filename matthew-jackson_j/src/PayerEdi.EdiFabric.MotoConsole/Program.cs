using EdiFabric.Templates.Hipaa5010;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PayerEdi.Ingestion.Extensions;
using PayerEdi.Ingestion.S3;
using PayerEdi.Pharmacy.Data.Extensions;
using PayerEdi.Pharmacy.Data.Hipaa837p;
using PayerEdi.Pharmacy.Extensions;
using PayerEdi.Pharmacy.Services;
using Serilog;
using System.Diagnostics;
using System.Globalization;
using System.Net.Sockets;

namespace PayerEdi.EdiFabric.MotoConsole;

/// <summary>
/// Entry point for local moto-backed S3 ingestion and SQL persistence validation.
/// </summary>
internal static class Program
{
    /// <summary>
    /// Boots service dependencies, runs ingestion, and returns process exit code.
    /// </summary>
    static async Task<int> Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.Console()
            .CreateLogger();

        MotoProcess? motoProcess = null;

        try
        {
            var configuration = BuildConfiguration();
            var options = MotoOptions.FromConfiguration(configuration, args);
            var connectionString = configuration.GetConnectionString("HipaaDb");
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new InvalidOperationException("Configuration key 'ConnectionStrings:HipaaDb' is required.");

            motoProcess = new MotoProcess(options);
            await motoProcess.StartAsync();

            IServiceCollection services = new ServiceCollection();
            services.AddLogging(logging =>
            {
                logging.ClearProviders();
                logging.AddSerilog(Log.Logger, dispose: false);
            });
            services.AddIngestionServices(configuration);
            services.AddHipaa837pDbContext(_ => connectionString);
            services.AddPharmacyServices();
            services.AddSingleton(options);
            services.AddSingleton<MotoConsoleRunner>();
            services.AddS3Consumer(configure =>
            {
                configure.EndpointUrl = options.EndpointUrl;
                configure.Region = options.Region;
                configure.AccessKey = options.AccessKey;
                configure.SecretKey = options.SecretKey;
                configure.ForcePathStyle = true;
            });

            await using var provider = services.BuildServiceProvider(new ServiceProviderOptions
            {
                ValidateScopes = true,
                ValidateOnBuild = true
            });

            var runner = provider.GetRequiredService<MotoConsoleRunner>();
            return await runner.RunAsync();
        }
        catch (Exception exception)
        {
            Log.Fatal(exception, "Moto console failed.");
            return 1;
        }
        finally
        {
            if (motoProcess is not null)
                await motoProcess.DisposeAsync();

            Log.CloseAndFlush();
        }
    }

    private static IConfiguration BuildConfiguration()
    {
        return new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
            .Build();
    }
}

/// <summary>
/// Coordinates S3 upload/download and ingestion assertions for the sample transaction.
/// </summary>
internal sealed class MotoConsoleRunner(
    ILogger<MotoConsoleRunner> logger,
    IServiceProvider provider,
    MotoOptions options)
{
    /// <summary>
    /// Executes the end-to-end moto ingestion workflow and verifies SQL persistence.
    /// </summary>
    public async Task<int> RunAsync()
    {
        logger.LogInformation("Starting moto ingestion for bucket '{Bucket}'", options.Bucket);

        await provider.MigrateHipaa837pAsync();

        await using var scope = provider.CreateAsyncScope();
        var s3 = scope.ServiceProvider.GetRequiredService<IS3Consumer>();
        var ingestion = scope.ServiceProvider.GetRequiredService<IHipaa837pIngestionService>();
        var dbContext = scope.ServiceProvider.GetRequiredService<Hipaa837pDbContext>();

        await s3.EnsureBucketExistsAsync(options.Bucket);

        var samplePath = Path.Combine(AppContext.BaseDirectory, options.SampleFileName);
        if (!File.Exists(samplePath))
            throw new FileNotFoundException($"Sample file not found at '{samplePath}'.", samplePath);

        var inboundPrefix = options.Prefix.Trim('/');
        var inboundKey = string.IsNullOrWhiteSpace(inboundPrefix)
            ? options.SampleFileName
            : $"{inboundPrefix}/{options.SampleFileName}";

        await using (var sampleStream = File.OpenRead(samplePath))
        {
            await s3.UploadAsync(options.Bucket, inboundKey, sampleStream);
        }
        logger.LogInformation("Uploaded '{SampleFile}' to s3://{Bucket}/{Key}", options.SampleFileName, options.Bucket, inboundKey);

        var payload = await s3.DownloadAsync(options.Bucket, inboundKey);
        await using var ediStream = new MemoryStream(payload);

        var items = await ingestion.IngestAsync(ediStream);
        var ingested = items.OfType<TS837P>().SingleOrDefault();
        if (ingested is null)
            throw new InvalidOperationException("Ingestion did not return a TS837P transaction.");

        var existsInDb = await dbContext.Set<TS837P>().AnyAsync(x => x.Id == ingested.Id);
        if (!existsInDb)
            throw new InvalidOperationException($"TS837P with Id={ingested.Id} was not found in the database.");

        logger.LogInformation("Ingested TS837P Id={TransactionId} and validated persistence.", ingested.Id);
        return 0;
    }
}

/// <summary>
/// Runtime options for moto endpoint, bucket naming, and moto lifecycle control.
/// </summary>
internal sealed class MotoOptions
{
    public string EndpointUrl { get; init; } = string.Empty;
    public string Region { get; init; } = string.Empty;
    public string AccessKey { get; init; } = string.Empty;
    public string SecretKey { get; init; } = string.Empty;
    public string Bucket { get; init; } = string.Empty;
    public string Prefix { get; init; } = string.Empty;
    public string SampleFileName { get; init; } = string.Empty;
    public bool StartMoto { get; init; }
    public bool KillExistingMoto { get; init; }
    public bool KillMotoOnExit { get; init; }

    /// <summary>
    /// Loads options from configuration and applies CLI overrides.
    /// </summary>
    public static MotoOptions FromConfiguration(IConfiguration configuration, string[] args)
    {
        var s3Section = configuration.GetSection("S3");
        var motoSection = s3Section.GetSection("Moto");
        var configured = new MotoOptions
        {
            EndpointUrl = s3Section["EndpointUrl"] ?? string.Empty,
            Region = s3Section["Region"] ?? string.Empty,
            AccessKey = s3Section["AccessKey"] ?? string.Empty,
            SecretKey = s3Section["SecretKey"] ?? string.Empty,
            Bucket = s3Section["Bucket"] ?? string.Empty,
            Prefix = s3Section["Prefix"] ?? string.Empty,
            SampleFileName = configuration["Ingestion:SampleFilePath"] ?? string.Empty,
            StartMoto = motoSection.GetValue<bool?>("StartMoto") ?? false,
            KillExistingMoto = motoSection.GetValue<bool?>("KillExistingMoto") ?? false,
            KillMotoOnExit = motoSection.GetValue<bool?>("KillMotoOnExit") ?? false
        };

        var values = ParseArgs(args);
        var options = new MotoOptions
        {
            EndpointUrl = GetArg(values, "--endpoint") ?? configured.EndpointUrl,
            Region = GetArg(values, "--region") ?? configured.Region,
            AccessKey = GetArg(values, "--access-key") ?? configured.AccessKey,
            SecretKey = GetArg(values, "--secret-key") ?? configured.SecretKey,
            Bucket = GetArg(values, "--bucket") ?? configured.Bucket,
            Prefix = GetArg(values, "--prefix") ?? configured.Prefix,
            SampleFileName = GetArg(values, "--sample-file") ?? configured.SampleFileName,
            StartMoto = ParseBoolean(GetArg(values, "--start-moto"), configured.StartMoto),
            KillExistingMoto = ParseBoolean(GetArg(values, "--kill-existing-moto"), configured.KillExistingMoto),
            KillMotoOnExit = ParseBoolean(GetArg(values, "--kill-moto-on-exit"), configured.KillMotoOnExit)
        };

        Validate(options);
        return options;
    }

    private static Dictionary<string, string> ParseArgs(string[] args)
    {
        var values = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        for (var index = 0; index < args.Length - 1; index++)
        {
            var key = args[index];
            if (!key.StartsWith("--", StringComparison.Ordinal))
                continue;

            values[key] = args[index + 1];
            index++;
        }

        return values;
    }

    private static string? GetArg(IReadOnlyDictionary<string, string> args, string key)
        => args.TryGetValue(key, out var value) && !string.IsNullOrWhiteSpace(value) ? value : null;

    private static bool ParseBoolean(string? value, bool fallback)
    {
        if (string.IsNullOrWhiteSpace(value))
            return fallback;

        if (bool.TryParse(value, out var parsed))
            return parsed;

        return fallback;
    }

    private static void Validate(MotoOptions options)
    {
        if (string.IsNullOrWhiteSpace(options.EndpointUrl))
            throw new InvalidOperationException("Configuration key 'S3:EndpointUrl' is required.");
        if (string.IsNullOrWhiteSpace(options.Region))
            throw new InvalidOperationException("Configuration key 'S3:Region' is required.");
        if (string.IsNullOrWhiteSpace(options.AccessKey))
            throw new InvalidOperationException("Configuration key 'S3:AccessKey' is required.");
        if (string.IsNullOrWhiteSpace(options.SecretKey))
            throw new InvalidOperationException("Configuration key 'S3:SecretKey' is required.");
        if (string.IsNullOrWhiteSpace(options.Bucket))
            throw new InvalidOperationException("Configuration key 'S3:Bucket' is required.");
        if (string.IsNullOrWhiteSpace(options.Prefix))
            throw new InvalidOperationException("Configuration key 'S3:Prefix' is required.");
        if (string.IsNullOrWhiteSpace(options.SampleFileName))
            throw new InvalidOperationException("Configuration key 'Ingestion:SampleFilePath' is required.");
    }
}

/// <summary>
/// Manages optional moto process startup/shutdown and local port cleanup.
/// </summary>
internal sealed class MotoProcess(MotoOptions options) : IAsyncDisposable
{
    private Process? _process;
    private bool _startedByThisProcess;
    private string _host = string.Empty;
    private int _port;

    /// <summary>
    /// Starts moto when configured and waits for endpoint availability.
    /// </summary>
    public async Task StartAsync()
    {
        if (!TryGetLocalEndpoint(options.EndpointUrl, out _host, out _port))
            throw new InvalidOperationException($"Endpoint '{options.EndpointUrl}' is invalid for local moto startup.");

        if (options.KillExistingMoto)
            await KillProcessesOnEndpointAsync("pre-start cleanup");

        if (!options.StartMoto)
            return;

        if (IsPortOpen(_host, _port))
        {
            Log.Information("Moto appears to be already running at {Endpoint}. Reusing existing process.", options.EndpointUrl);
            return;
        }

        var repoRoot = ResolveRepositoryRoot();
        var serviceDir = Path.Combine(repoRoot, "src", "PayerEdi.S3Service");
        var scriptPath = Path.Combine(serviceDir, "run_moto_s3.py");
        var pythonPath = Path.Combine(serviceDir, ".venv", "Scripts", "python.exe");
        if (!File.Exists(pythonPath))
            throw new FileNotFoundException($"Moto Python runtime was not found at '{pythonPath}'.");
        if (!File.Exists(scriptPath))
            throw new FileNotFoundException($"Moto script was not found at '{scriptPath}'.");

        var startInfo = new ProcessStartInfo
        {
            FileName = pythonPath,
            Arguments = $"\"{scriptPath}\" --host {_host} --port {_port}",
            WorkingDirectory = serviceDir,
            UseShellExecute = false,
            RedirectStandardOutput = false,
            RedirectStandardError = false
        };

        _process = Process.Start(startInfo)
            ?? throw new InvalidOperationException("Unable to start moto process.");
        _startedByThisProcess = true;

        await WaitForPortAsync(_host, _port, TimeSpan.FromSeconds(10));
        Log.Information("Started moto process (PID: {Pid}) at {Endpoint}.", _process.Id, options.EndpointUrl);
    }

    /// <summary>
    /// Stops moto started by this process or performs configured cleanup on exit.
    /// </summary>
    public async ValueTask DisposeAsync()
    {
        if (_startedByThisProcess && _process is not null)
        {
            if (_process.HasExited)
                return;

            _process.Kill(entireProcessTree: true);
            await _process.WaitForExitAsync();
            Log.Information("Stopped moto process (PID: {Pid}).", _process.Id);
            return;
        }

        if (options.KillMotoOnExit)
            await KillProcessesOnEndpointAsync("shutdown");
    }

    private static bool TryGetLocalEndpoint(string endpointUrl, out string host, out int port)
    {
        host = string.Empty;
        port = 0;

        if (!Uri.TryCreate(endpointUrl, UriKind.Absolute, out var uri))
            return false;

        host = uri.Host;
        port = uri.Port;
        if (port <= 0)
            return false;

        return host.Equals("127.0.0.1", StringComparison.OrdinalIgnoreCase) ||
               host.Equals("localhost", StringComparison.OrdinalIgnoreCase);
    }

    private static bool IsPortOpen(string host, int port)
    {
        using var client = new TcpClient();
        try
        {
            client.Connect(host, port);
            return true;
        }
        catch
        {
            return false;
        }
    }

    private async Task KillProcessesOnEndpointAsync(string reason)
    {
        var pids = FindListeningPidsOnPort(_port);
        if (pids.Count == 0)
            return;

        foreach (var pid in pids)
        {
            try
            {
                var process = Process.GetProcessById(pid);
                Log.Information("Killing process PID {Pid} ({Name}) on port {Port} during {Reason}.", pid, process.ProcessName, _port, reason);
                process.Kill(entireProcessTree: true);
                await process.WaitForExitAsync();
            }
            catch (Exception exception)
            {
                Log.Warning(exception, "Failed to kill PID {Pid} on port {Port}.", pid, _port);
            }
        }

        await WaitForPortClosedAsync(_host, _port, TimeSpan.FromSeconds(5));
    }

    private static HashSet<int> FindListeningPidsOnPort(int port)
    {
        var startInfo = new ProcessStartInfo
        {
            FileName = "netstat",
            Arguments = "-ano -p tcp",
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            CreateNoWindow = true
        };

        using var process = Process.Start(startInfo)
            ?? throw new InvalidOperationException("Unable to start netstat.");
        var output = process.StandardOutput.ReadToEnd();
        process.WaitForExit();

        var expectedPortToken = ":" + port.ToString(CultureInfo.InvariantCulture);
        var pids = new HashSet<int>();

        foreach (var line in output.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries))
        {
            var trimmed = line.Trim();
            if (!trimmed.StartsWith("TCP", StringComparison.OrdinalIgnoreCase))
                continue;
            if (!trimmed.Contains(expectedPortToken, StringComparison.Ordinal))
                continue;
            if (!trimmed.Contains("LISTENING", StringComparison.OrdinalIgnoreCase))
                continue;

            var parts = trimmed.Split((char[]?)null, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length < 5)
                continue;

            if (int.TryParse(parts[^1], NumberStyles.Integer, CultureInfo.InvariantCulture, out var pid))
                pids.Add(pid);
        }

        return pids;
    }

    private static async Task WaitForPortAsync(string host, int port, TimeSpan timeout)
    {
        var deadline = DateTime.UtcNow + timeout;
        while (DateTime.UtcNow < deadline)
        {
            if (IsPortOpen(host, port))
                return;

            await Task.Delay(100);
        }

        throw new TimeoutException($"Timed out waiting for moto to listen on {host}:{port}.");
    }

    private static async Task WaitForPortClosedAsync(string host, int port, TimeSpan timeout)
    {
        var deadline = DateTime.UtcNow + timeout;
        while (DateTime.UtcNow < deadline)
        {
            if (!IsPortOpen(host, port))
                return;

            await Task.Delay(100);
        }
    }

    private static string ResolveRepositoryRoot()
    {
        var directory = new DirectoryInfo(AppContext.BaseDirectory);
        while (directory is not null)
        {
            var solutionPath = Path.Combine(directory.FullName, "PayerEdi.Pharmacy.slnx");
            if (File.Exists(solutionPath))
                return directory.FullName;

            directory = directory.Parent;
        }

        throw new InvalidOperationException("Could not resolve repository root.");
    }
}
