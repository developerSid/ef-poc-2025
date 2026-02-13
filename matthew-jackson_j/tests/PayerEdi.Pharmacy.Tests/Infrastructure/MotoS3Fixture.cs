using System.Diagnostics;
using System.Net.Sockets;
using PayerEdi.Ingestion.Extensions;
using PayerEdi.Ingestion.S3;

namespace PayerEdi.Pharmacy.Tests.Infrastructure;

public sealed class MotoS3Fixture : IAsyncLifetime
{
    private Process? _motoProcess;
    private string _baseDirectory = string.Empty;
    private ServiceProvider _provider = default!;

    public int Port { get; private set; }
    public string EndpointUrl => $"http://127.0.0.1:{Port}";

    public TService GetService<TService>() where TService : notnull
    {
        if (_provider is null)
            throw new InvalidOperationException("Fixture provider is not initialized.");

        return _provider.GetRequiredService<TService>();
    }

    public async ValueTask InitializeAsync()
    {
        _baseDirectory = ResolveRepositoryRoot();
        Port = GetFreePort();

        var pythonPath = ResolveVenvPythonPath(_baseDirectory);
        var motoPath = Path.Combine(_baseDirectory, "src", "PayerEdi.S3Service", "run_moto_s3.py");

        if (pythonPath is null)
        {
            throw new InvalidOperationException(
                "Python venv executable was not found under src/PayerEdi.S3Service/.venv. " +
                "Run src/PayerEdi.S3Service/setup.ps1 (Windows) or create a venv and install requirements (Linux/macOS).");
        }

        if (!File.Exists(motoPath))
        {
            throw new InvalidOperationException($"Moto launcher not found at '{motoPath}'.");
        }

        var startInfo = new ProcessStartInfo
        {
            FileName = pythonPath,
            Arguments = $"\"{motoPath}\" --host 127.0.0.1 --port {Port}",
            WorkingDirectory = Path.GetDirectoryName(motoPath)!,
            UseShellExecute = false,
            RedirectStandardError = true,
            RedirectStandardOutput = true
        };

        _motoProcess = Process.Start(startInfo)
            ?? throw new InvalidOperationException("Unable to start moto process.");

        await WaitForPortAsync(Port, TimeSpan.FromSeconds(10));

        var services = new ServiceCollection();
        services.AddS3Consumer(options =>
        {
            options.EndpointUrl = EndpointUrl;
            options.Region = "us-east-1";
            options.AccessKey = "test";
            options.SecretKey = "test";
            options.ForcePathStyle = true;
        });

        _provider = services.BuildServiceProvider();
    }

    public async ValueTask DisposeAsync()
    {
        if (_provider is not null)
            await _provider.DisposeAsync();

        if (_motoProcess is null)
            return;

        if (!_motoProcess.HasExited)
        {
            _motoProcess.Kill(entireProcessTree: true);
            await _motoProcess.WaitForExitAsync();
        }
    }

    private static string ResolveRepositoryRoot()
    {
        var current = AppContext.BaseDirectory;
        var directory = new DirectoryInfo(current);
        while (directory is not null)
        {
            var solutionPath = Path.Combine(directory.FullName, "PayerEdi.Pharmacy.slnx");
            if (File.Exists(solutionPath))
                return directory.FullName;

            directory = directory.Parent;
        }

        throw new InvalidOperationException("Could not resolve repository root.");
    }

    private static int GetFreePort()
    {
        var listener = new TcpListener(System.Net.IPAddress.Loopback, 0);
        listener.Start();
        var port = ((System.Net.IPEndPoint)listener.LocalEndpoint).Port;
        listener.Stop();
        return port;
    }

    private static async Task WaitForPortAsync(int port, TimeSpan timeout)
    {
        var deadline = DateTime.UtcNow.Add(timeout);
        while (DateTime.UtcNow < deadline)
        {
            using var client = new TcpClient();
            try
            {
                await client.ConnectAsync("127.0.0.1", port);
                return;
            }
            catch (SocketException)
            {
                await Task.Delay(100);
            }
        }

        throw new TimeoutException($"Timed out waiting for moto to listen on port {port}.");
    }

    private static string? ResolveVenvPythonPath(string repositoryRoot)
    {
        var serviceRoot = Path.Combine(repositoryRoot, "src", "PayerEdi.S3Service");
        var windowsPath = Path.Combine(serviceRoot, ".venv", "Scripts", "python.exe");
        if (File.Exists(windowsPath))
            return windowsPath;

        var posixPath = Path.Combine(serviceRoot, ".venv", "bin", "python");
        if (File.Exists(posixPath))
            return posixPath;

        return null;
    }
}