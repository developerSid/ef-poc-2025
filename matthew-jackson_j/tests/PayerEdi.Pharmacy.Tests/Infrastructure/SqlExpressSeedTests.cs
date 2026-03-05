// Intentionally kept commented out as an optional seed-style persistence example for future reactivation.
//using PayerEdi.Pharmacy.Data.Hipaa837p;

//namespace PayerEdi.Pharmacy.Tests.Infrastructure;

//public sealed class SqlExpressSeedTests : DbTestBase
//{
//    public SqlExpressSeedTests(DbFixture fixture) : base(fixture)
//    {
//    }

//    [Fact]
//    public async Task CanPersistAndReadBhtSegment()
//    {
//        var context = GetService<Hipaa837pDbContext>();

//        var entity = new BHT_BeginningOfHierarchicalTransaction_8
//        {
//            HierarchicalStructureCode_01 = "0019",
//            TransactionSetPurposeCode_02 = "00",
//            SubmitterTransactionIdentifier_03 = "TEST-837P",
//            TransactionSetCreationDate_04 = "20260210",
//            TransactionSetCreationTime_05 = "1234",
//            TransactionTypeCode_06 = "CH"
//        };

//        context.BHT.Add(entity);
//        await context.SaveChangesAsync(CancellationToken);

//        var saved = await context.BHT
//            .OfType<BHT_BeginningOfHierarchicalTransaction_8>()
//            .SingleAsync(CancellationToken);

//        Assert.Equal(entity.SubmitterTransactionIdentifier_03, saved.SubmitterTransactionIdentifier_03);
//        Assert.Equal(entity.TransactionSetCreationDate_04, saved.TransactionSetCreationDate_04);
//        Assert.Equal(entity.TransactionTypeCode_06, saved.TransactionTypeCode_06);
//    }
//}
