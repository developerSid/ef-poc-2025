using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Moq;
using X12EDI837.Ingestion.Domain;
using X12EDI837.Ingestion.Infrastructure;
using X12EDI837.Ingestion.Infrastructure.FileSource;
using X12EDI837.Ingestion.Services;
using X12EDI837.Ingestion.Tests.Helpers;
using EdiFabric.Templates.Hipaa5010;

namespace X12EDI837.Ingestion.Tests;

/// <summary>
/// Unit tests for EdiIngestionService.
/// Uses in-memory EF Core database — no real SQL Server needed.
/// </summary>
public class EdiIngestionServiceTests
{
    // -------------------------------------------------------------------------
    // Helpers
    // -------------------------------------------------------------------------

    private static EdiIngestionService CreateService(
        AppDbContext db,
        IFileSource fileSource,
        IEdiParser parser,
        string provider = "local")
    {
        var opts = Options.Create(new FileSourceOptions { Provider = provider });
        return new EdiIngestionService(
            fileSource,
            parser,
            db,
            opts,
            NullLogger<EdiIngestionService>.Instance);
    }

    /// <summary>
    /// Builds a minimal EdiParseResult with the given ClaimId (CLM01).
    /// </summary>
    private static EdiParseResult BuildValidResult(string claimId, string fileName = "test.edi")
    {
        var tx = new TS837P();
        var loop2000A = new Loop_2000A_837P();
        var loop2000B = new Loop_2000B_837P();
        var loop2300  = new Loop_2300_837P();

        loop2300.CLM_ClaimInformation = new CLM_ClaimInformation_3
        {
            PatientControlNumber_01    = claimId,
            TotalClaimChargeAmount_02  = "100.00",
        };

        loop2000B.Loop2300 = [loop2300];
        loop2000A.Loop2000B = [loop2000B];
        tx.Loop2000A = [loop2000A];

        return new EdiParseResult
        {
            Transaction              = tx,
            TransactionControlNumber = "0001",
            InterchangeControlNumber = "000000101",
            GroupControlNumber       = "101",
            SourceFileName           = fileName,
            IsValid                  = true,
            ValidationErrors         = [],
        };
    }

    /// <summary>Builds an invalid EdiParseResult with SNIP errors.</summary>
    private static EdiParseResult BuildInvalidResult(string claimId, string fileName = "bad.edi")
    {
        var valid = BuildValidResult(claimId, fileName);
        return new EdiParseResult
        {
            Transaction              = valid.Transaction,
            TransactionControlNumber = valid.TransactionControlNumber,
            SourceFileName           = fileName,
            IsValid                  = false,
            ValidationErrors         =
            [
                new SnipError(1, "PRV", 22, "[PRV at pos 22] UnexpectedSegment"),
                new SnipError(1, "N3",  24, "[N3 at pos 24] UnexpectedSegment"),
            ],
        };
    }

    // -------------------------------------------------------------------------
    // EdiIngestionService — Valid claim
    // -------------------------------------------------------------------------

    [Fact]
    public async Task ProcessFileAsync_ValidClaim_SavesClaimToDatabase()
    {
        // Arrange
        using var db      = TestDbContextFactory.Create();
        var fileSource    = new Mock<IFileSource>();
        var parser        = new Mock<IEdiParser>();
        var result        = BuildValidResult("CLM-001");

        fileSource.Setup(f => f.OpenReadAsync("test.edi", It.IsAny<CancellationToken>()))
                  .ReturnsAsync(new MemoryStream());
        parser.Setup(p => p.Parse(It.IsAny<Stream>(), "test.edi"))
              .Returns([result]);

        var svc = CreateService(db, fileSource.Object, parser.Object, provider: "local");

        // Act
        await svc.ProcessFileAsync("test.edi");

        // Assert
        var claim = db.Claims.SingleOrDefault();
        Assert.NotNull(claim);
        Assert.Equal("CLM-001", claim.ClaimId);
        Assert.True(claim.IsValid);
        Assert.Equal(0, claim.SnipErrorCount);
        Assert.Equal("local", claim.FileSource);
    }

    [Fact]
    public async Task ProcessFileAsync_ValidClaim_SetsSourceFileName()
    {
        // Arrange
        using var db   = TestDbContextFactory.Create();
        var fileSource = new Mock<IFileSource>();
        var parser     = new Mock<IEdiParser>();
        var result     = BuildValidResult("CLM-002", "inbound/837-file.edi");

        fileSource.Setup(f => f.OpenReadAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                  .ReturnsAsync(new MemoryStream());
        parser.Setup(p => p.Parse(It.IsAny<Stream>(), It.IsAny<string>()))
              .Returns([result]);

        var svc = CreateService(db, fileSource.Object, parser.Object);

        // Act
        await svc.ProcessFileAsync("inbound/837-file.edi");

        // Assert
        var claim = db.Claims.Single();
        Assert.Equal("inbound/837-file.edi", claim.SourceFileName);
    }

    // -------------------------------------------------------------------------
    // EdiIngestionService — Invalid claim (SNIP errors)
    // -------------------------------------------------------------------------

    [Fact]
    public async Task ProcessFileAsync_InvalidClaim_SavesClaimWithSnipErrors()
    {
        // Arrange
        using var db   = TestDbContextFactory.Create();
        var fileSource = new Mock<IFileSource>();
        var parser     = new Mock<IEdiParser>();
        var result     = BuildInvalidResult("CLM-BAD");

        fileSource.Setup(f => f.OpenReadAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                  .ReturnsAsync(new MemoryStream());
        parser.Setup(p => p.Parse(It.IsAny<Stream>(), It.IsAny<string>()))
              .Returns([result]);

        var svc = CreateService(db, fileSource.Object, parser.Object);

        // Act
        await svc.ProcessFileAsync("bad.edi");

        // Assert — claim saved with IsValid = false
        var claim = db.Claims.SingleOrDefault();
        Assert.NotNull(claim);
        Assert.False(claim.IsValid);
        Assert.Equal(2, claim.SnipErrorCount);

        // Assert — SNIP errors saved and linked to the claim
        var errors = db.SnipValidationErrors.ToList();
        Assert.Equal(2, errors.Count);
        Assert.All(errors, e => Assert.Equal(claim.Id, e.ClaimId));
    }

    [Fact]
    public async Task ProcessFileAsync_InvalidClaim_SnipErrorMessagesAreSaved()
    {
        // Arrange
        using var db   = TestDbContextFactory.Create();
        var fileSource = new Mock<IFileSource>();
        var parser     = new Mock<IEdiParser>();
        var result     = BuildInvalidResult("CLM-ERR");

        fileSource.Setup(f => f.OpenReadAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                  .ReturnsAsync(new MemoryStream());
        parser.Setup(p => p.Parse(It.IsAny<Stream>(), It.IsAny<string>()))
              .Returns([result]);

        var svc = CreateService(db, fileSource.Object, parser.Object);

        // Act
        await svc.ProcessFileAsync("bad.edi");

        // Assert
        var errors = db.SnipValidationErrors.Select(e => e.ErrorMessage).ToList();
        Assert.Contains("[PRV at pos 22] UnexpectedSegment", errors);
        Assert.Contains("[N3 at pos 24] UnexpectedSegment", errors);
    }

    // -------------------------------------------------------------------------
    // EdiIngestionService — Duplicate detection
    // -------------------------------------------------------------------------

    [Fact]
    public async Task ProcessFileAsync_DuplicateValidClaim_SkipsSecondInsert()
    {
        // Arrange
        using var db   = TestDbContextFactory.Create();
        var fileSource = new Mock<IFileSource>();
        var parser     = new Mock<IEdiParser>();
        var result     = BuildValidResult("CLM-DUP");

        fileSource.Setup(f => f.OpenReadAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                  .ReturnsAsync(new MemoryStream());
        parser.Setup(p => p.Parse(It.IsAny<Stream>(), It.IsAny<string>()))
              .Returns([result]);

        var svc = CreateService(db, fileSource.Object, parser.Object);

        // Act — run twice
        await svc.ProcessFileAsync("test.edi");
        await svc.ProcessFileAsync("test.edi");

        // Assert — only 1 claim in DB
        Assert.Equal(1, db.Claims.Count());
    }

    [Fact]
    public async Task ProcessFileAsync_DuplicateInvalidClaim_SkipsSecondInsert()
    {
        // Arrange
        using var db   = TestDbContextFactory.Create();
        var fileSource = new Mock<IFileSource>();
        var parser     = new Mock<IEdiParser>();
        var result     = BuildInvalidResult("CLM-DUP-BAD");

        fileSource.Setup(f => f.OpenReadAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                  .ReturnsAsync(new MemoryStream());
        parser.Setup(p => p.Parse(It.IsAny<Stream>(), It.IsAny<string>()))
              .Returns([result]);

        var svc = CreateService(db, fileSource.Object, parser.Object);

        // Act — run twice
        await svc.ProcessFileAsync("bad.edi");
        await svc.ProcessFileAsync("bad.edi");

        // Assert — only 1 claim in DB
        Assert.Equal(1, db.Claims.Count());
    }

    // -------------------------------------------------------------------------
    // EdiIngestionService — FileSource provider stamped correctly
    // -------------------------------------------------------------------------

    [Fact]
    public async Task ProcessFileAsync_S3Provider_StampsFileSourceAsS3()
    {
        // Arrange
        using var db   = TestDbContextFactory.Create();
        var fileSource = new Mock<IFileSource>();
        var parser     = new Mock<IEdiParser>();
        var result     = BuildValidResult("CLM-S3");

        fileSource.Setup(f => f.OpenReadAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                  .ReturnsAsync(new MemoryStream());
        parser.Setup(p => p.Parse(It.IsAny<Stream>(), It.IsAny<string>()))
              .Returns([result]);

        var svc = CreateService(db, fileSource.Object, parser.Object, provider: "s3");

        // Act
        await svc.ProcessFileAsync("inbound/file.edi");

        // Assert
        var claim = db.Claims.Single();
        Assert.Equal("s3", claim.FileSource);
    }

    [Fact]
    public async Task ProcessFileAsync_LocalProvider_StampsFileSourceAsLocal()
    {
        // Arrange
        using var db   = TestDbContextFactory.Create();
        var fileSource = new Mock<IFileSource>();
        var parser     = new Mock<IEdiParser>();
        var result     = BuildValidResult("CLM-LOCAL");

        fileSource.Setup(f => f.OpenReadAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                  .ReturnsAsync(new MemoryStream());
        parser.Setup(p => p.Parse(It.IsAny<Stream>(), It.IsAny<string>()))
              .Returns([result]);

        var svc = CreateService(db, fileSource.Object, parser.Object, provider: "local");

        // Act
        await svc.ProcessFileAsync("file.edi");

        // Assert
        var claim = db.Claims.Single();
        Assert.Equal("local", claim.FileSource);
    }

    // -------------------------------------------------------------------------
    // EdiIngestionService — Multiple files
    // -------------------------------------------------------------------------

    [Fact]
    public async Task RunAsync_MultipleFiles_ProcessesAllFiles()
    {
        // Arrange
        using var db   = TestDbContextFactory.Create();
        var fileSource = new Mock<IFileSource>();
        var parser     = new Mock<IEdiParser>();

        fileSource.Setup(f => f.ListFilesAsync(It.IsAny<CancellationToken>()))
                  .ReturnsAsync(new[] { "file1.edi", "file2.edi" });

        fileSource.Setup(f => f.OpenReadAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                  .ReturnsAsync(new MemoryStream());

        parser.Setup(p => p.Parse(It.IsAny<Stream>(), "file1.edi"))
              .Returns([BuildValidResult("CLM-F1", "file1.edi")]);
        parser.Setup(p => p.Parse(It.IsAny<Stream>(), "file2.edi"))
              .Returns([BuildValidResult("CLM-F2", "file2.edi")]);

        var svc = CreateService(db, fileSource.Object, parser.Object);

        // Act
        await svc.RunAsync();

        // Assert — both claims saved
        Assert.Equal(2, db.Claims.Count());
    }

    [Fact]
    public async Task RunAsync_OneFileFails_ContinuesProcessingRemainingFiles()
    {
        // Arrange
        using var db   = TestDbContextFactory.Create();
        var fileSource = new Mock<IFileSource>();
        var parser     = new Mock<IEdiParser>();

        fileSource.Setup(f => f.ListFilesAsync(It.IsAny<CancellationToken>()))
                  .ReturnsAsync(new[] { "bad.edi", "good.edi" });

        // bad.edi throws an exception during download
        fileSource.Setup(f => f.OpenReadAsync("bad.edi", It.IsAny<CancellationToken>()))
                  .ThrowsAsync(new IOException("S3 error"));

        fileSource.Setup(f => f.OpenReadAsync("good.edi", It.IsAny<CancellationToken>()))
                  .ReturnsAsync(new MemoryStream());

        parser.Setup(p => p.Parse(It.IsAny<Stream>(), "good.edi"))
              .Returns([BuildValidResult("CLM-GOOD", "good.edi")]);

        var svc = CreateService(db, fileSource.Object, parser.Object);

        // Act — should NOT throw even though bad.edi fails
        await svc.RunAsync();

        // Assert — good.edi still processed
        Assert.Equal(1, db.Claims.Count());
        Assert.Equal("CLM-GOOD", db.Claims.Single().ClaimId);
    }

    // -------------------------------------------------------------------------
    // EdiIngestionService — Empty file (no transactions)
    // -------------------------------------------------------------------------

    [Fact]
    public async Task ProcessFileAsync_EmptyFile_SavesNothingToDatabase()
    {
        // Arrange
        using var db   = TestDbContextFactory.Create();
        var fileSource = new Mock<IFileSource>();
        var parser     = new Mock<IEdiParser>();

        fileSource.Setup(f => f.OpenReadAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                  .ReturnsAsync(new MemoryStream());
        parser.Setup(p => p.Parse(It.IsAny<Stream>(), It.IsAny<string>()))
              .Returns([]); // no transactions

        var svc = CreateService(db, fileSource.Object, parser.Object);

        // Act
        await svc.ProcessFileAsync("empty.edi");

        // Assert
        Assert.Equal(0, db.Claims.Count());
    }
}
