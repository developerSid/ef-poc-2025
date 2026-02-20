using EdiFabric.Core.Model.Edi.X12;
using EdiFabric.Templates.Hipaa5010;
using PayerEdi.Ingestion.S3;

namespace PayerEdi.Pharmacy.Tests.Infrastructure;

[Collection("db")]
/// <summary>
/// Exercises sample EDI parsing and 837P persistence using the moto-backed S3 fixture.
/// </summary>
public sealed class MotoS3EdiFileTests(DbFixture dbFixture, MotoS3Fixture fixture) : IClassFixture<MotoS3Fixture>
{
    /// <summary>
    /// Verifies each uploaded sample can be downloaded from S3 and parsed to the expected transaction type.
    /// </summary>
    [Theory]
    [InlineData("837-sample.edi", typeof(TS837D))]
    [InlineData("837i-sample.edi", typeof(TS837I))]
    [InlineData("837p-sample.edi", typeof(TS837P))]
    public async Task UploadedEdiFileCanBeReadFromS3AndParsed(string fileName, Type expectedTransactionType)
    {
        const string Bucket = "payeredi-edi-tests";
        var key = $"incoming/{fileName}";
        var cancellationToken = TestContext.Current.CancellationToken;

        var consumer = fixture.GetService<IS3Consumer>();
        var tokenProvider = fixture.GetService<IEdiTokenProvider>();
        var readerFactory = fixture.GetService<IEdiReaderFactory>();

        await consumer.EnsureBucketExistsAsync(Bucket, cancellationToken);

        await using (var uploadStream = SampleFile.Open(fileName))
        {
            await consumer.UploadAsync(Bucket, key, uploadStream, cancellationToken);
        }

        var bytes = await consumer.DownloadAsync(Bucket, key, cancellationToken);
        Assert.NotEmpty(bytes);

        // The parser requires EdiFabric licensing to be initialized before reading.
        tokenProvider.InitToken();

        await using var downloadStream = new MemoryStream(bytes);
        using var reader = readerFactory.Create(downloadStream);
        var items = reader.ReadAll();

        Assert.NotEmpty(items);
        Assert.Contains(items, item => item is ISA);
        Assert.Contains(items, item => item.GetType() == expectedTransactionType);
    }

    /// <summary>
    /// Validates end-to-end 837P ingestion from moto S3 through SQL persistence.
    /// </summary>
    [Fact]
    public async Task TS837PIngestionFromMotoFinishes()
    {
        await dbFixture.ResetAsync();

        const string Bucket = "payeredi-edi-tests";
        const string Key = "incoming/837p-sample.edi";
        var cancellationToken = TestContext.Current.CancellationToken;

        var consumer = fixture.GetService<IS3Consumer>();
        await consumer.EnsureBucketExistsAsync(Bucket, cancellationToken);

        await using (var uploadStream = SampleFile.Open("837p-sample.edi"))
        {
            await consumer.UploadAsync(Bucket, Key, uploadStream, cancellationToken);
        }

        var payload = await consumer.DownloadAsync(Bucket, Key, cancellationToken);
        await using var stream = new MemoryStream(payload);

        using var scope = dbFixture.CreateScope();
        var ingestion = scope.ServiceProvider.GetRequiredService<IHipaa837pIngestionService>();
        var items = await ingestion.IngestAsync(stream, cancellationToken);

        Assert.Equal(5, items.Count);
        var transaction = Assert.Single(items.OfType<TS837P>());
        Assert.True(transaction.Id > 0);

        var dbContext = scope.ServiceProvider.GetRequiredService<Hipaa837pDbContext>();
        var persisted837p = await dbContext.Set<TS837P>().CountAsync(cancellationToken);
        Assert.Equal(1, persisted837p);
    }
}
