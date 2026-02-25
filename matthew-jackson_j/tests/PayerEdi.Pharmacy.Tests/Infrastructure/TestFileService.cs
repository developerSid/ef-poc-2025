using PayerEdi.Ingestion.IO;

namespace PayerEdi.Pharmacy.Tests.Infrastructure;

/// <summary>
/// Test-only file service that returns caller-provided payload bytes.
/// </summary>
public sealed class TestFileService : IFileService
{
    private readonly Dictionary<(string Bucket, string Key), byte[]> _files = new();

    public Task PushAsync(string bucket, string key, byte[] payload, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(bucket);
        ArgumentException.ThrowIfNullOrWhiteSpace(key);
        ArgumentNullException.ThrowIfNull(payload);
        _files[(bucket, key)] = payload;
        return Task.CompletedTask;
    }

    public Task<byte[]> PullAsync(string bucket, string key, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(bucket);
        ArgumentException.ThrowIfNullOrWhiteSpace(key);
        if (_files.TryGetValue((bucket, key), out var payload))
            return Task.FromResult(payload);

        throw new FileNotFoundException($"Test payload '{key}' not found in bucket '{bucket}'.");
    }

    public Task<IReadOnlyList<string>> ListAsync(string bucket, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(bucket);
        var keys = _files.Keys
            .Where(x => x.Bucket.Equals(bucket, StringComparison.Ordinal))
            .Select(x => x.Key)
            .ToArray();
        return Task.FromResult<IReadOnlyList<string>>(keys);
    }
}
