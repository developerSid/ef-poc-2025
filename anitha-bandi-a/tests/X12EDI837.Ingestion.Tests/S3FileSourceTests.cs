using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Moq;
using X12EDI837.Ingestion.Infrastructure.FileSource;

namespace X12EDI837.Ingestion.Tests;

/// <summary>
/// Unit tests for S3FileSource — uses Moq to mock IAmazonS3.
/// No real AWS or Moto server needed.
/// </summary>
public class S3FileSourceTests
{
    private const string Bucket = "edi-bucket";
    private const string Prefix = "inbound/";

    private static S3FileSource CreateSource(IAmazonS3 s3Client, string? fileName = null) =>
        new(s3Client,
            Options.Create(new FileSourceOptions
            {
                S3BucketName = Bucket,
                S3Prefix     = Prefix,
                FileName     = fileName ?? string.Empty,
            }),
            NullLogger<S3FileSource>.Instance);

    // -------------------------------------------------------------------------
    // ListFilesAsync — FileName configured (single file mode)
    // -------------------------------------------------------------------------

    [Fact]
    public async Task ListFilesAsync_WithFileName_ReturnsSingleKeyWithoutCallingS3()
    {
        // Arrange
        var s3 = new Mock<IAmazonS3>(MockBehavior.Strict); // Strict = no unexpected calls
        var svc = CreateSource(s3.Object, fileName: "837-sample.edi");

        // Act
        var files = (await svc.ListFilesAsync()).ToList();

        // Assert — returns constructed key, S3 ListObjects never called
        Assert.Single(files);
        Assert.Equal("inbound/837-sample.edi", files[0]);
        s3.Verify(x => x.ListObjectsV2Async(
            It.IsAny<ListObjectsV2Request>(),
            It.IsAny<CancellationToken>()), Times.Never);
    }

    // -------------------------------------------------------------------------
    // ListFilesAsync — No FileName (list all mode)
    // -------------------------------------------------------------------------

    [Fact]
    public async Task ListFilesAsync_NoFileName_ReturnsAllEdiFilesFromBucket()
    {
        // Arrange
        var s3 = new Mock<IAmazonS3>();
        s3.Setup(x => x.ListObjectsV2Async(
                It.IsAny<ListObjectsV2Request>(),
                It.IsAny<CancellationToken>()))
          .ReturnsAsync(new ListObjectsV2Response
          {
              S3Objects =
              [
                  new() { Key = "inbound/file1.edi" },
                  new() { Key = "inbound/file2.edi" },
                  new() { Key = "inbound/readme.txt" }, // should be excluded
              ]
          });

        var svc = CreateSource(s3.Object);

        // Act
        var files = (await svc.ListFilesAsync()).ToList();

        // Assert
        Assert.Equal(2, files.Count);
        Assert.Contains("inbound/file1.edi", files);
        Assert.Contains("inbound/file2.edi", files);
        Assert.DoesNotContain("inbound/readme.txt", files);
    }

    [Fact]
    public async Task ListFilesAsync_NoFileName_EmptyBucket_ReturnsEmptyList()
    {
        // Arrange
        var s3 = new Mock<IAmazonS3>();
        s3.Setup(x => x.ListObjectsV2Async(
                It.IsAny<ListObjectsV2Request>(),
                It.IsAny<CancellationToken>()))
          .ReturnsAsync(new ListObjectsV2Response { S3Objects = [] });

        var svc = CreateSource(s3.Object);

        // Act
        var files = (await svc.ListFilesAsync()).ToList();

        // Assert
        Assert.Empty(files);
    }

    [Fact]
    public async Task ListFilesAsync_NoFileName_FiltersOnlyEdiExtension()
    {
        // Arrange
        var s3 = new Mock<IAmazonS3>();
        s3.Setup(x => x.ListObjectsV2Async(
                It.IsAny<ListObjectsV2Request>(),
                It.IsAny<CancellationToken>()))
          .ReturnsAsync(new ListObjectsV2Response
          {
              S3Objects =
              [
                  new() { Key = "inbound/claim.EDI" },  // uppercase .EDI — should match
                  new() { Key = "inbound/claim.edi" },  // lowercase — should match
                  new() { Key = "inbound/file.json" },  // excluded
                  new() { Key = "inbound/file.xml" },   // excluded
              ]
          });

        var svc = CreateSource(s3.Object);

        // Act
        var files = (await svc.ListFilesAsync()).ToList();

        // Assert
        Assert.Equal(2, files.Count);
    }

    // -------------------------------------------------------------------------
    // OpenReadAsync
    // -------------------------------------------------------------------------

    [Fact]
    public async Task OpenReadAsync_ValidKey_ReturnsStreamWithContent()
    {
        // Arrange
        var content     = "ISA*00*test~"u8.ToArray();
        var s3          = new Mock<IAmazonS3>();
        var s3Response  = new GetObjectResponse
        {
            ResponseStream = new MemoryStream(content),
        };

        s3.Setup(x => x.GetObjectAsync(Bucket, "inbound/file.edi", It.IsAny<CancellationToken>()))
          .ReturnsAsync(s3Response);

        var svc = CreateSource(s3.Object);

        // Act
        await using var stream = await svc.OpenReadAsync("inbound/file.edi");
        var bytes = new byte[content.Length];
        _ = await stream.ReadAsync(bytes);

        // Assert
        Assert.Equal(content, bytes);
    }

    [Fact]
    public async Task OpenReadAsync_ReturnsMemoryStream_NotS3Stream()
    {
        // Arrange — S3 stream closes after use; we need an independent MemoryStream
        var s3 = new Mock<IAmazonS3>();
        s3.Setup(x => x.GetObjectAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
          .ReturnsAsync(new GetObjectResponse { ResponseStream = new MemoryStream([1, 2, 3]) });

        var svc = CreateSource(s3.Object);

        // Act
        var stream = await svc.OpenReadAsync("inbound/file.edi");

        // Assert — caller gets a MemoryStream they own (not the raw S3 stream)
        Assert.IsType<MemoryStream>(stream);
        Assert.Equal(0, stream.Position); // rewound to start
        await stream.DisposeAsync();
    }
}
