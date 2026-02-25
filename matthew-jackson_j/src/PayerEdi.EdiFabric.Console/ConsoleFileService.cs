using Microsoft.Extensions.Logging;
using PayerEdi.Ingestion.IO;

namespace PayerEdi.EdiFabric.Console;

internal sealed class ConsoleFileService(ILogger<ConsoleFileService> logger) : IFileService
{
    public async Task PushAsync(string bucket, string key, byte[] payload, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(bucket);
        ArgumentException.ThrowIfNullOrWhiteSpace(key);
        ArgumentNullException.ThrowIfNull(payload);

        var path = ResolvePath(bucket, key);
        var directory = Path.GetDirectoryName(path)
            ?? throw new InvalidOperationException($"Unable to resolve directory for '{path}'.");
        Directory.CreateDirectory(directory);
        await File.WriteAllBytesAsync(path, payload, cancellationToken);
        logger.LogInformation("Pushed local file '{Key}' to bucket '{Bucket}'.", key, bucket);
    }

    public Task<byte[]> PullAsync(string bucket, string key, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(bucket);
        ArgumentException.ThrowIfNullOrWhiteSpace(key);
        var path = ResolvePath(bucket, key);
        if (!File.Exists(path))
            throw new FileNotFoundException($"File not found at '{path}'.", path);
        logger.LogInformation("Pulled local file '{Key}' from bucket '{Bucket}'.", key, bucket);
        return File.ReadAllBytesAsync(path, cancellationToken);
    }

    public Task<IReadOnlyList<string>> ListAsync(string bucket, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(bucket);
        var bucketRoot = Path.GetFullPath(bucket);
        if (!Directory.Exists(bucketRoot))
            return Task.FromResult<IReadOnlyList<string>>(Array.Empty<string>());

        var keys = Directory
            .GetFiles(bucketRoot, "*", SearchOption.AllDirectories)
            .Select(file => Path.GetRelativePath(bucketRoot, file).Replace('\\', '/'))
            .ToArray();
        logger.LogInformation("Listed {Count} local file(s) in bucket '{Bucket}'.", keys.Length, bucket);
        return Task.FromResult<IReadOnlyList<string>>(keys);
    }

    private static string ResolvePath(string bucket, string key)
    {
        var bucketRoot = Path.GetFullPath(bucket);
        var normalizedKey = key.Replace('/', Path.DirectorySeparatorChar);
        var fullPath = Path.GetFullPath(Path.Combine(bucketRoot, normalizedKey));
        if (!fullPath.StartsWith(bucketRoot, StringComparison.OrdinalIgnoreCase))
            throw new InvalidOperationException("Key resolves outside the bucket root.");
        return fullPath;
    }
}
