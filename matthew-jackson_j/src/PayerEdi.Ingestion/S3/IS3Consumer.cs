namespace PayerEdi.Ingestion.S3;

/// <summary>
/// Minimal S3 operations required by ingestion flows.
/// </summary>
public interface IS3Consumer
{
    /// <summary>Ensures the target bucket exists.</summary>
    Task EnsureBucketExistsAsync(string bucketName, CancellationToken cancellationToken = default);
    /// <summary>Uploads a stream to an object key.</summary>
    Task UploadAsync(string bucketName, string key, Stream content, CancellationToken cancellationToken = default);
    /// <summary>Downloads an object payload as bytes.</summary>
    Task<byte[]> DownloadAsync(string bucketName, string key, CancellationToken cancellationToken = default);
    /// <summary>Moves an object by copy then delete within the same bucket.</summary>
    Task MoveAsync(string bucketName, string sourceKey, string destinationKey, CancellationToken cancellationToken = default);
    /// <summary>Lists object keys under a prefix.</summary>
    Task<IReadOnlyList<string>> ListKeysAsync(string bucketName, string prefix, CancellationToken cancellationToken = default);
}
