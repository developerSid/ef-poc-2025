using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Util;
using Microsoft.Extensions.Options;

namespace PayerEdi.Ingestion.S3;

/// <summary>
/// AWS S3 implementation of <see cref="IS3Consumer"/> used by local moto and real S3 endpoints.
/// </summary>
public sealed class S3Consumer : IS3Consumer, IDisposable
{
    private readonly IAmazonS3 _s3Client;

    /// <summary>
    /// Creates a consumer from configured <see cref="S3ConsumerOptions"/>.
    /// </summary>
    public S3Consumer(IOptions<S3ConsumerOptions> options)
        : this(CreateClient(options.Value))
    {
    }

    /// <summary>
    /// Creates a consumer from an existing S3 client instance.
    /// </summary>
    public S3Consumer(IAmazonS3 s3Client)
    {
        _s3Client = s3Client ?? throw new ArgumentNullException(nameof(s3Client));
    }

    /// <inheritdoc />
    public async Task EnsureBucketExistsAsync(string bucketName, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(bucketName);

        if (await AmazonS3Util.DoesS3BucketExistV2Async(_s3Client, bucketName))
            return;

        await _s3Client.PutBucketAsync(new PutBucketRequest
        {
            BucketName = bucketName
        }, cancellationToken);
    }

    /// <inheritdoc />
    public async Task UploadAsync(string bucketName, string key, Stream content, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(bucketName);
        ArgumentException.ThrowIfNullOrWhiteSpace(key);
        ArgumentNullException.ThrowIfNull(content);

        await EnsureBucketExistsAsync(bucketName, cancellationToken);

        if (content.CanSeek)
            content.Seek(0, SeekOrigin.Begin);

        await _s3Client.PutObjectAsync(new PutObjectRequest
        {
            BucketName = bucketName,
            Key = key,
            InputStream = content
        }, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<byte[]> DownloadAsync(string bucketName, string key, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(bucketName);
        ArgumentException.ThrowIfNullOrWhiteSpace(key);

        var response = await _s3Client.GetObjectAsync(new GetObjectRequest
        {
            BucketName = bucketName,
            Key = key
        }, cancellationToken);

        await using var responseStream = response.ResponseStream;
        using var memoryStream = new MemoryStream();
        await responseStream.CopyToAsync(memoryStream, cancellationToken);
        return memoryStream.ToArray();
    }

    /// <inheritdoc />
    public async Task MoveAsync(string bucketName, string sourceKey, string destinationKey, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(bucketName);
        ArgumentException.ThrowIfNullOrWhiteSpace(sourceKey);
        ArgumentException.ThrowIfNullOrWhiteSpace(destinationKey);

        await _s3Client.CopyObjectAsync(new CopyObjectRequest
        {
            SourceBucket = bucketName,
            SourceKey = sourceKey,
            DestinationBucket = bucketName,
            DestinationKey = destinationKey
        }, cancellationToken);

        await _s3Client.DeleteObjectAsync(new DeleteObjectRequest
        {
            BucketName = bucketName,
            Key = sourceKey
        }, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<IReadOnlyList<string>> ListKeysAsync(string bucketName, string prefix, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(bucketName);
        prefix ??= string.Empty;

        var keys = new List<string>();
        string? continuationToken = null;

        do
        {
            var response = await _s3Client.ListObjectsV2Async(new ListObjectsV2Request
            {
                BucketName = bucketName,
                Prefix = prefix,
                ContinuationToken = continuationToken
            }, cancellationToken);

            keys.AddRange(response.S3Objects.Select(x => x.Key));
            continuationToken = response.IsTruncated == true ? response.NextContinuationToken : null;
        }
        while (continuationToken is not null);

        return keys;
    }

    /// <summary>
    /// Disposes the underlying S3 client.
    /// </summary>
    public void Dispose()
    {
        _s3Client.Dispose();
    }

    private static IAmazonS3 CreateClient(S3ConsumerOptions options)
    {
        if (string.IsNullOrWhiteSpace(options.EndpointUrl))
            throw new InvalidOperationException("Configuration key for S3 endpoint URL is required.");
        if (string.IsNullOrWhiteSpace(options.Region))
            throw new InvalidOperationException("Configuration key for S3 region is required.");
        if (string.IsNullOrWhiteSpace(options.AccessKey))
            throw new InvalidOperationException("Configuration key for S3 access key is required.");
        if (string.IsNullOrWhiteSpace(options.SecretKey))
            throw new InvalidOperationException("Configuration key for S3 secret key is required.");

        var config = new AmazonS3Config
        {
            ServiceURL = options.EndpointUrl,
            ForcePathStyle = options.ForcePathStyle
        };

        return new AmazonS3Client(options.AccessKey, options.SecretKey, config);
    }
}
