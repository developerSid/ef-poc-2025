using X12EDI837.Ingestion.Domain;

namespace X12EDI837.Ingestion.Tests;

/// <summary>
/// Unit tests for Domain entity defaults and relationships.
/// </summary>
public class DomainModelTests
{
    // -------------------------------------------------------------------------
    // Claim defaults
    // -------------------------------------------------------------------------

    [Fact]
    public void Claim_DefaultIsValid_IsTrue()
    {
        var claim = new Claim();
        Assert.True(claim.IsValid);
    }

    [Fact]
    public void Claim_DefaultSnipErrorCount_IsZero()
    {
        var claim = new Claim();
        Assert.Equal(0, claim.SnipErrorCount);
    }

    [Fact]
    public void Claim_DefaultCollections_AreEmpty()
    {
        var claim = new Claim();
        Assert.Empty(claim.ServiceLines);
        Assert.Empty(claim.DiagnosisCodes);
        Assert.Empty(claim.SnipValidationErrors);
    }

    [Fact]
    public void Claim_DefaultIngestedAt_IsUtcNow()
    {
        var before = DateTime.UtcNow.AddSeconds(-1);
        var claim  = new Claim();
        var after  = DateTime.UtcNow.AddSeconds(1);

        Assert.InRange(claim.IngestedAt, before, after);
    }

    [Fact]
    public void Claim_CanAddServiceLines()
    {
        var claim = new Claim();
        claim.ServiceLines.Add(new ServiceLine { ProcedureCode = "99213" });
        Assert.Single(claim.ServiceLines);
    }

    [Fact]
    public void Claim_CanAddDiagnosisCodes()
    {
        var claim = new Claim();
        claim.DiagnosisCodes.Add(new DiagnosisCode { Code = "J0290" });
        Assert.Single(claim.DiagnosisCodes);
    }

    [Fact]
    public void Claim_CanAddSnipValidationErrors()
    {
        var claim = new Claim();
        claim.SnipValidationErrors.Add(new SnipValidationError
        {
            ErrorMessage = "[PRV at pos 22] UnexpectedSegment"
        });
        Assert.Single(claim.SnipValidationErrors);
    }

    // -------------------------------------------------------------------------
    // SnipValidationError defaults
    // -------------------------------------------------------------------------

    [Fact]
    public void SnipValidationError_DefaultRecordedAt_IsUtcNow()
    {
        var before = DateTime.UtcNow.AddSeconds(-1);
        var error  = new SnipValidationError();
        var after  = DateTime.UtcNow.AddSeconds(1);

        Assert.InRange(error.RecordedAt, before, after);
    }

    // -------------------------------------------------------------------------
    // FileSourceOptions defaults
    // -------------------------------------------------------------------------

    [Fact]
    public void FileSourceOptions_DefaultProvider_IsLocal()
    {
        var opts = new X12EDI837.Ingestion.Infrastructure.FileSource.FileSourceOptions();
        Assert.Equal("local", opts.Provider);
    }

    [Fact]
    public void FileSourceOptions_DefaultFileName_IsEmpty()
    {
        var opts = new X12EDI837.Ingestion.Infrastructure.FileSource.FileSourceOptions();
        Assert.Equal(string.Empty, opts.FileName);
    }

    // -------------------------------------------------------------------------
    // EdiParseResult
    // -------------------------------------------------------------------------

    [Fact]
    public void EdiParseResult_IsValid_True_ValidationErrorsEmpty()
    {
        var result = new X12EDI837.Ingestion.Services.EdiParseResult
        {
            Transaction              = null!,
            TransactionControlNumber = "0001",
            SourceFileName           = "test.edi",
            IsValid                  = true,
            ValidationErrors         = [],
        };

        Assert.True(result.IsValid);
        Assert.Empty(result.ValidationErrors);
    }

    [Fact]
    public void EdiParseResult_IsValid_False_HasValidationErrors()
    {
        var result = new X12EDI837.Ingestion.Services.EdiParseResult
        {
            Transaction              = null!,
            TransactionControlNumber = "0001",
            SourceFileName           = "bad.edi",
            IsValid                  = false,
            ValidationErrors         = [new X12EDI837.Ingestion.Services.SnipError(1, "PRV", 22, "[PRV at pos 22] UnexpectedSegment")],
        };

        Assert.False(result.IsValid);
        Assert.Single(result.ValidationErrors);
    }
}
