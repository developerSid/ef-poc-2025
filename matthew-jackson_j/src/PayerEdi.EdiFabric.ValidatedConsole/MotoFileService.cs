using Microsoft.Extensions.Logging;
using PayerEdi.Ingestion.IO;
using PayerEdi.Ingestion.S3;

namespace PayerEdi.EdiFabric.ValidatedConsole;

internal sealed class MotoFileService(
    ILogger<MotoFileService> logger,
    IS3Consumer s3Consumer,
    ValidatedOptions options) : IFileService
{
    public async Task PushAsync(string bucket, string key, byte[] payload, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(bucket);
        ArgumentException.ThrowIfNullOrWhiteSpace(key);
        ArgumentNullException.ThrowIfNull(payload);

        await s3Consumer.EnsureBucketExistsAsync(bucket, cancellationToken);
        await using var stream = new MemoryStream(payload, writable: false);
        await s3Consumer.UploadAsync(bucket, key, stream, cancellationToken);
        logger.LogInformation("Uploaded '{SampleFile}' to s3://{Bucket}/{Key}", options.SampleFileName, bucket, key);
    }

    public Task<byte[]> PullAsync(string bucket, string key, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(bucket);
        ArgumentException.ThrowIfNullOrWhiteSpace(key);
        logger.LogInformation("Pulling s3://{Bucket}/{Key}", bucket, key);
        return s3Consumer.DownloadAsync(bucket, key, cancellationToken);
    }

    public Task<IReadOnlyList<string>> ListAsync(string bucket, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(bucket);
        logger.LogInformation("Listing files in bucket '{Bucket}'.", bucket);
        return s3Consumer.ListKeysAsync(bucket, string.Empty, cancellationToken);
    }
}
