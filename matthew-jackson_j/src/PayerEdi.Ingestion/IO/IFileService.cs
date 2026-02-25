namespace PayerEdi.Ingestion.IO;

/// <summary>
/// Provides file operations for pushing, pulling, and listing files by bucket.
/// </summary>
public interface IFileService
{
    /// <summary>
    /// Pushes file bytes to a bucket/key location.
    /// </summary>
    Task PushAsync(string bucket, string key, byte[] payload, CancellationToken cancellationToken = default);

    /// <summary>
    /// Pulls file bytes from a bucket/key location.
    /// </summary>
    Task<byte[]> PullAsync(string bucket, string key, CancellationToken cancellationToken = default);

    /// <summary>
    /// Lists all file keys in a bucket.
    /// </summary>
    Task<IReadOnlyList<string>> ListAsync(string bucket, CancellationToken cancellationToken = default);
}
