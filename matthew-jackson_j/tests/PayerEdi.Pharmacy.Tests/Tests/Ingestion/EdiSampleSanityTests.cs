namespace PayerEdi.Pharmacy.Ingestion.Tests;

public class EdiSampleSanityTests : IClassFixture<IngestionFixture>
{
    private readonly IngestionFixture _fixture;

    public EdiSampleSanityTests(IngestionFixture fixture)
    {
        _fixture = fixture;
    }

    [Theory]
    [InlineData("837-sample.edi")]
    [InlineData("837i-sample.edi")]
    [InlineData("837p-sample.edi")]
    public void SamplesReturnNonEmptyContext(string fileName)
    {
        using var scope = _fixture.CreateScope();
        var tokenProvider = scope.ServiceProvider.GetRequiredService<IEdiTokenProvider>();
        tokenProvider.InitToken();

        using var stream = SampleFile.Open(fileName);
        
        Assert.NotEqual(-1, stream.ReadByte());
    }
}
