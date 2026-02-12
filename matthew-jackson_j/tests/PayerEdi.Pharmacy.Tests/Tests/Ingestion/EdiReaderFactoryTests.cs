using EdiFabric.Framework.Readers;
using System.Text;

namespace PayerEdi.Pharmacy.Ingestion.Tests;

public class EdiReaderFactoryTests : IClassFixture<IngestionFixture>
{
    private readonly IngestionFixture _fixture;

    public EdiReaderFactoryTests(IngestionFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void CreateSettingsWhenX12ReturnsX12ReaderSettings()
    {
        using var scope = _fixture.CreateScope();
        var factory = scope.ServiceProvider.GetRequiredService<IEdiReaderFactory>();

        var settings = factory.CreateSettings(Stream.Null, EdiStandard.X12);
        Assert.NotNull(settings);
        Assert.IsType<X12ReaderSettings>(settings);
    }

    [Theory]
    [InlineData(EdiStandard.Edifact)]
    [InlineData(EdiStandard.Hl7)]
    [InlineData(EdiStandard.NcpdpTelecom)]
    [InlineData(EdiStandard.NcpdpScript)]
    [InlineData(EdiStandard.Unknown)]
    public void CreateSettingsWhenNotX12ThrowsNotSupported(EdiStandard standard)
    {
        using var scope = _fixture.CreateScope();
        var factory = scope.ServiceProvider.GetRequiredService<IEdiReaderFactory>();

        Assert.Throws<NotSupportedException>(() => factory.CreateSettings(Stream.Null, standard));
    }

    [Fact]
    public void CreateWhenX12DetectedReturnsX12Reader()
    {
        using var scope = _fixture.CreateScope();
        var tokenProvider = scope.ServiceProvider.GetRequiredService<IEdiTokenProvider>();
        tokenProvider.InitToken();

        var bytes = Encoding.ASCII.GetBytes("ISA*00*          ");
        using var stream = new MemoryStream(bytes);

        var factory = scope.ServiceProvider.GetRequiredService<IEdiReaderFactory>();
        var reader = factory.Create(stream);

        Assert.NotNull(reader);
        Assert.IsType<EdiReader>(reader);
    }
}
