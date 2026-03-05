using EdiFabric.Framework.Readers;
using System.Text;

namespace PayerEdi.Pharmacy.Tests.Ingestion;

/// <summary>
/// Verifies reader-factory behavior for supported and unsupported EDI standards.
/// </summary>
public class EdiReaderFactoryTests(IngestionFixture fixture) : IClassFixture<IngestionFixture>
{
    /// <summary>
    /// Confirms X12 standard maps to the expected EdiFabric reader settings type.
    /// </summary>
    [Fact]
    public void CreateSettingsWhenX12ReturnsX12ReaderSettings()
    {
        using var scope = fixture.CreateScope();
        var factory = scope.ServiceProvider.GetRequiredService<IEdiReaderFactory>();

        var settings = factory.CreateSettings(Stream.Null, EdiStandard.X12);
        Assert.NotNull(settings);
        Assert.IsType<X12ReaderSettings>(settings);
    }

    /// <summary>
    /// Confirms non-X12 standards are rejected by the current factory implementation.
    /// </summary>
    [Theory]
    [InlineData(EdiStandard.Edifact)]
    [InlineData(EdiStandard.Hl7)]
    [InlineData(EdiStandard.NcpdpTelecom)]
    [InlineData(EdiStandard.NcpdpScript)]
    [InlineData(EdiStandard.Unknown)]
    public void CreateSettingsWhenNotX12ThrowsNotSupported(EdiStandard standard)
    {
        using var scope = fixture.CreateScope();
        var factory = scope.ServiceProvider.GetRequiredService<IEdiReaderFactory>();

        Assert.Throws<NotSupportedException>(() => factory.CreateSettings(Stream.Null, standard));
    }

    /// <summary>
    /// Verifies stream sniffing plus token initialization produces a concrete X12 reader wrapper.
    /// </summary>
    [Fact]
    public void CreateWhenX12DetectedReturnsX12Reader()
    {
        using var scope = fixture.CreateScope();
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
