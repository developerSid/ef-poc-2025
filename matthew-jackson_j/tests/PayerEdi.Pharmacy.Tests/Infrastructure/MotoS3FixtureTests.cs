using System.Text;
using PayerEdi.Ingestion.S3;

namespace PayerEdi.Pharmacy.Tests.Infrastructure;

/// <summary>
/// Covers core S3 file operations against the local moto endpoint.
/// </summary>
public sealed class MotoS3FixtureTests(MotoS3Fixture fixture) : IClassFixture<MotoS3Fixture>
{
    /// <summary>
    /// Ensures upload, download, and move preserve sample EDI payload content.
    /// </summary>
    [Fact]
    public async Task UploadDownloadAndMoveSampleFileWorks()
    {
        const string Bucket = "payeredi-edi-tests";
        const string SourceKey = "incoming/837p-sample.edi";
        const string DestinationKey = "processed/837p-sample.edi";
        const string SampleFileName = "837p-sample.edi";
        var cancellationToken = TestContext.Current.CancellationToken;
        var consumer = fixture.GetService<IS3Consumer>();

        await consumer.EnsureBucketExistsAsync(Bucket, cancellationToken);

        await using var stream = SampleFile.Open(SampleFileName);
        await consumer.UploadAsync(Bucket, SourceKey, stream, cancellationToken);

        var sourceBytes = await consumer.DownloadAsync(Bucket, SourceKey, cancellationToken);
        Assert.NotEmpty(sourceBytes);

        await consumer.MoveAsync(Bucket, SourceKey, DestinationKey, cancellationToken);

        var movedBytes = await consumer.DownloadAsync(Bucket, DestinationKey, cancellationToken);
        Assert.Equal(sourceBytes, movedBytes);

        var movedText = Encoding.ASCII.GetString(movedBytes);
        Assert.Contains("ISA*", movedText);
    }
}
