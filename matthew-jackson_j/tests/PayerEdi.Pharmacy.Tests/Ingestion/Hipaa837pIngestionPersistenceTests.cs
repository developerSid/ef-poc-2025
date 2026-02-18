using EdiFabric.Core.Model.Edi.X12;
using EdiFabric.Templates.Hipaa5010;

namespace PayerEdi.Pharmacy.Tests.Ingestion;

public sealed class Hipaa837pIngestionPersistenceTests(DbFixture fixture) : DbTestBase(fixture)
{

    [Theory]
    [InlineData("837p-sample.edi")]
    public async Task TS837PIngestionFinishes(string resourceName)
    {
        using var stream = SampleFile.Open(resourceName);

        var ingestion = GetService<IHipaa837pIngestionService>();
        var expectedItems = await ingestion.IngestAsync(stream, CancellationToken);
        Assert.Equal(5, expectedItems.Count);
        var expected = Assert.Single(expectedItems.OfType<TS837P>());
        Assert.True(expected.Id > 0);

        var isa = expectedItems.OfType<ISA>().FirstOrDefault();
        Assert.NotNull(isa);

        var gs = expectedItems.OfType<GS>().FirstOrDefault();
        Assert.NotNull(gs);

        using var reloadContext = GetService<Hipaa837pDbContext>();

        var actual = await reloadContext
            .Set<TS837P>()
            .Include(x => x.BHT_BeginningOfHierarchicalTransaction)
            .Include(x => x.ST)
            .Include(x => x.SE)
            .SingleAsync(CancellationToken);
        Assert.True(actual.Id > 0);

        Assert.Equal(expected.Id, actual.Id);

        Assert.NotNull(expected.ST);
        Assert.NotNull(actual.ST);
        Assert.Equal(expected.ST.TransactionSetIdentifierCode_01, actual.ST.TransactionSetIdentifierCode_01);
        Assert.Equal(expected.ST.TransactionSetControlNumber_02, actual.ST.TransactionSetControlNumber_02);

        Assert.NotNull(expected.BHT_BeginningOfHierarchicalTransaction);
        Assert.NotNull(actual.BHT_BeginningOfHierarchicalTransaction);
        Assert.Equal(
            expected.BHT_BeginningOfHierarchicalTransaction.HierarchicalStructureCode_01,
            actual.BHT_BeginningOfHierarchicalTransaction.HierarchicalStructureCode_01);
        Assert.Equal(
            expected.BHT_BeginningOfHierarchicalTransaction.TransactionSetPurposeCode_02,
            actual.BHT_BeginningOfHierarchicalTransaction.TransactionSetPurposeCode_02);
        Assert.Equal(
            expected.BHT_BeginningOfHierarchicalTransaction.SubmitterTransactionIdentifier_03,
            actual.BHT_BeginningOfHierarchicalTransaction.SubmitterTransactionIdentifier_03);
    }

    [Fact]
    public async Task IngestWhenInputIsNotEdiThrowsAndPersistsNothing()
    {
        using var stream = new MemoryStream("not-an-edi-payload"u8.ToArray());

        var ingestion = GetService<IHipaa837pIngestionService>();

        await Assert.ThrowsAsync<NotSupportedException>(() => ingestion.IngestAsync(stream, CancellationToken));

        using var reloadContext = GetService<Hipaa837pDbContext>();
        var persistedTransactions = await reloadContext.Set<TS837P>().CountAsync(CancellationToken);
        Assert.Equal(0, persistedTransactions);
    }

    [Theory]
    [InlineData("837i-sample.edi")]
    public async Task TS837IReadFinishes(string resourceName)
    {
        using var stream = SampleFile.Open(resourceName);

        var ingestion = GetService<IHipaa837pIngestionService>();
        var expectedItems = await ingestion.IngestAsync(stream, CancellationToken);
        Assert.Equal(5, expectedItems.Count);
        var expected = Assert.Single(expectedItems.OfType<TS837I>());
        Assert.True(expected.Id > 0);
    }

    [Theory]
    [InlineData("837-sample.edi")]
    public async Task TS837DReadFinishes(string resourceName)
    {
        using var stream = SampleFile.Open(resourceName);

        var ingestion = GetService<IHipaa837pIngestionService>();
        var expectedItems = await ingestion.IngestAsync(stream, CancellationToken);
        Assert.Equal(5, expectedItems.Count);
        var expected = Assert.Single(expectedItems.OfType<TS837D>());
        Assert.True(expected.Id > 0);
    }
}