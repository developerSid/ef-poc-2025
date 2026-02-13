namespace PayerEdi.Ingestion.S3;

public interface IS3Consumer
{
    Task EnsureBucketExistsAsync(string bucketName, CancellationToken cancellationToken = default);
    Task UploadAsync(string bucketName, string key, Stream content, CancellationToken cancellationToken = default);
    Task<byte[]> DownloadAsync(string bucketName, string key, CancellationToken cancellationToken = default);
    Task MoveAsync(string bucketName, string sourceKey, string destinationKey, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<string>> ListKeysAsync(string bucketName, string prefix, CancellationToken cancellationToken = default);
}