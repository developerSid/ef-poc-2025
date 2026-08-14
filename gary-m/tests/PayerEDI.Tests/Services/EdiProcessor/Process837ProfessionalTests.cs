using PayerEDI.Data.Models.Claims;
using PayerEDI.Tests.Fixtures;

namespace PayerEDI.Tests.Services.EdiProcessor;

public class Process837ProfessionalTests : IClassFixture<TestLoggingFixture>,
    IClassFixture<TestEdiFabricFixture>
{
    private readonly Data.Services.EdiProcessor _processor;

    public Process837ProfessionalTests(TestLoggingFixture logging, TestEdiFabricFixture testEdiFabricFixture)
    {
        _ = testEdiFabricFixture;
        _processor = new Data.Services.EdiProcessor(logging.CreateLogger<Data.Services.EdiProcessor>());
    }

    [Fact]
    public void Process837ProfessionalAll()
    {
        var samplePath = Path.Combine(
            AppContext.BaseDirectory,
            "samples",
            "EDI",
            "837P-all-fields.edi"
        );

        using var ediStream = File.OpenRead(samplePath);
        
        var claims = _processor.ProcessEdi(ediStream);

        Assert.NotEmpty(claims);
        Assert.Single(claims);
        var firstClaim = claims[0];
        
        Assert.IsType<ProfessionalCareClaim>(firstClaim);
        Assert.NotNull(firstClaim);
    }
}