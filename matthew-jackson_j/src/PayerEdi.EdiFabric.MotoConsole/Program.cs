using EdiFabric.Templates.Hipaa5010;
using Microsoft.EntityFrameworkCore;
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
using DataStartup = PayerEdi.Pharmacy.Data.Extensions.Startup;

namespace PayerEdi.EdiFabric.MotoConsole;

internal static class Program
{
    static async Task<int> Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.Console()
            .CreateLogger();

        MotoProcess? motoProcess = null;

        try
        {
            var options = MotoOptions.FromArgs(args);
            var connectionString = ResolveConnectionString();
            motoProcess = new MotoProcess(options);
            await motoProcess.StartAsync();

            IServiceCollection services = new ServiceCollection();
            services.AddLogging(logging =>
            {
                logging.ClearProviders();
                logging.AddSerilog(Log.Logger, dispose: false);
            });
            services.AddIngestionServices();
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

    private static string ResolveConnectionString()
    {
        var configuredConnection = Environment.GetEnvironmentVariable("HIPAA_DB_CONNECTION", EnvironmentVariableTarget.Process)
            ?? Environment.GetEnvironmentVariable("HIPAA_DB_CONNECTION", EnvironmentVariableTarget.Machine);

        return string.IsNullOrWhiteSpace(configuredConnection)
            ? DataStartup.BuildSqlExpressConnectionString("PayerEdiPharmacy")
            : configuredConnection;
    }
}

internal sealed class MotoConsoleRunner(
    ILogger<MotoConsoleRunner> logger,
    IServiceProvider provider,
    MotoOptions options)
{
    private const string SampleFileName = "837p-sample.edi";

    public async Task<int> RunAsync()
    {
        logger.LogInformation("Starting moto ingestion for bucket '{Bucket}'", options.Bucket);

        await provider.MigrateHipaa837pAsync();

        await using var scope = provider.CreateAsyncScope();
        var s3 = scope.ServiceProvider.GetRequiredService<IS3Consumer>();
        var ingestion = scope.ServiceProvider.GetRequiredService<IHipaa837pIngestionService>();
        var dbContext = scope.ServiceProvider.GetRequiredService<Hipaa837pDbContext>();

        await s3.EnsureBucketExistsAsync(options.Bucket);

        var samplePath = Path.Combine(AppContext.BaseDirectory, SampleFileName);
        if (!File.Exists(samplePath))
            throw new FileNotFoundException($"Sample file not found at '{samplePath}'.", samplePath);

        var inboundPrefix = options.InboundPrefix.Trim('/');
        var inboundKey = string.IsNullOrWhiteSpace(inboundPrefix)
            ? SampleFileName
            : $"{inboundPrefix}/{SampleFileName}";

        await using (var sampleStream = File.OpenRead(samplePath))
        {
            await s3.UploadAsync(options.Bucket, inboundKey, sampleStream);
        }
        logger.LogInformation("Uploaded '{SampleFile}' to s3://{Bucket}/{Key}", SampleFileName, options.Bucket, inboundKey);

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

internal sealed class MotoOptions
{
    public string EndpointUrl { get; init; } = "http://127.0.0.1:5000";
    public string Region { get; init; } = "us-east-1";
    public string AccessKey { get; init; } = "test";
    public string SecretKey { get; init; } = "test";
    public string Bucket { get; init; } = "payeredi-edi";
    public string InboundPrefix { get; init; } = "inbound";
    public bool StartMoto { get; init; } = false;
    public bool KillExistingMoto { get; init; } = false;
    public bool KillMotoOnExit { get; init; } = false;

    public static MotoOptions FromArgs(string[] args)
    {
        var values = ParseArgs(args);
        return new MotoOptions
        {
            EndpointUrl = GetArg(values, "--endpoint") ?? "http://127.0.0.1:5000",
            Region = GetArg(values, "--region") ?? "us-east-1",
            AccessKey = GetArg(values, "--access-key") ?? "test",
            SecretKey = GetArg(values, "--secret-key") ?? "test",
            Bucket = GetArg(values, "--bucket") ?? "payeredi-edi",
            InboundPrefix = GetArg(values, "--prefix") ?? "inbound",
            StartMoto = ParseBoolean(GetArg(values, "--start-moto"), false),
            KillExistingMoto = ParseBoolean(GetArg(values, "--kill-existing-moto"), false),
            KillMotoOnExit = ParseBoolean(GetArg(values, "--kill-moto-on-exit"), false)
        };
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
}

internal sealed class MotoProcess(MotoOptions options) : IAsyncDisposable
{
    private Process? _process;
    private bool _startedByThisProcess;
    private string _host = string.Empty;
    private int _port;

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
