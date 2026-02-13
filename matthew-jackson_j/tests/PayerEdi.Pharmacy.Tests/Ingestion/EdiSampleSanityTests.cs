namespace PayerEdi.Pharmacy.Tests.Ingestion;

public class EdiSampleSanityTests(IngestionFixture fixture) : IClassFixture<IngestionFixture>
{
    [Theory]
    [InlineData("837-sample.edi")]
    [InlineData("837i-sample.edi")]
    [InlineData("837p-sample.edi")]
    public void SamplesReturnNonEmptyContext(string fileName)
    {
        using var scope = fixture.CreateScope();
        var tokenProvider = scope.ServiceProvider.GetRequiredService<IEdiTokenProvider>();
        tokenProvider.InitToken();

        using var stream = SampleFile.Open(fileName);
        
        Assert.NotEqual(-1, stream.ReadByte());
    }
}