using EdiFabric.Core.Model.Edi;
using EdiFabric.Core.Model.Edi.X12;
using EdiFabric.Framework.Readers;
using EdiFabric.Templates.Hipaa5010;
using Microsoft.Extensions.Logging;

namespace X12EDI837.Ingestion.Services;

/// <summary>
/// Parses raw X12 EDI 837P streams using EdiFabric and validates each transaction
/// against SNIP levels 1–4 (Type 1 – Type 4 syntax and balancing rules).
/// </summary>
/// <remarks>
/// SNIP levels applied:
/// - Type 1 – Integrity check (envelope/segment structure)
/// - Type 2 – Requirement check (mandatory elements present)
/// - Type 3 – Balancing (counts and totals match)
/// - Type 4 – Syntactical requirement (inter-segment rules)
///
/// Invalid transactions are not discarded; they are returned with
/// IsValid = false so the caller (mapper / ingestion service) can decide how to handle them.
/// </remarks>
public sealed class EdiParserService : IEdiParser
{
    private readonly ILogger<EdiParserService> _logger;

    // Validate through SNIP Type 4 (InterSegment).
    private static readonly ValidationSettings SnipValidationSettings = new()
    {
        ValidationLevel = ValidationLevel.InterSegment_SNIP4,
    };

    // Keep reading even when an envelope-level error is encountered so we
    // collect as many transactions as possible from the file.
    private static readonly X12ReaderSettings ReaderSettings = new()
    {
        ContinueOnError = true,
        NoEnvelope = false,
    };

    public EdiParserService(ILogger<EdiParserService> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public IEnumerable<EdiParseResult> Parse(Stream ediStream, string sourceFileName)
    {
        ArgumentNullException.ThrowIfNull(ediStream);
        ArgumentException.ThrowIfNullOrWhiteSpace(sourceFileName);

        _logger.LogInformation("Starting EDI parse for file: {SourceFileName}", sourceFileName);

        List<IEdiItem> ediItems;

        // Read all items in one pass; the reader is disposed before we iterate.
        try
        {
            using (var reader = new X12Reader(ediStream, "EdiFabric.Templates.Hipaa", ReaderSettings))
            {
                ediItems = [.. reader.ReadToEnd()];
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to read EDI stream for file: {SourceFileName}", sourceFileName);
            throw;
        }

        var transactionCount = ediItems.OfType<TS837P>().Count();

        _logger.LogInformation(
            "Found {TransactionCount} 837P transaction(s) in {SourceFileName}",
            transactionCount,
            sourceFileName
        );

        var results = new List<EdiParseResult>(transactionCount);

        // Track the current ISA/GS envelope as we walk the item list in order.
        string currentIsaControlNumber = string.Empty;
        string currentGsControlNumber  = string.Empty;

        foreach (var item in ediItems)
        {
            try
            {
                if (item is ISA isa)
                {
                    currentIsaControlNumber = isa.InterchangeControlNumber_13 ?? string.Empty;
                    continue;
                }

                if (item is GS gs)
                {
                    currentGsControlNumber = gs.GroupControlNumber_6 ?? string.Empty;
                    continue;
                }

                if (item is not TS837P transaction)
                    continue;

                var controlNumber = transaction.ST?.TransactionSetControlNumber_02 ?? "(unknown)";

                var isValid = transaction.IsValid(out var errorContext, SnipValidationSettings);

                List<SnipError> errors = [];

                if (!isValid && errorContext is not null)
                {
                    // Flatten() returns plain error strings from the EdiFabric error context tree.
                    errors = errorContext
                        .Flatten()
                        .Select(msg => new SnipError(
                            SnipLevel:       0,
                            Segment:         string.Empty,
                            SegmentPosition: null,
                            ErrorMessage:    msg
                        ))
                        .ToList();

                    _logger.LogWarning(
                        "Transaction {ControlNumber} in {SourceFileName} failed SNIP validation " +
                        "with {ErrorCount} error(s).",
                        controlNumber,
                        sourceFileName,
                        errors.Count
                    );

                    foreach (var error in errors)
                    {
                        _logger.LogWarning("  SNIP L{Level} [{Segment}] pos={Pos}: {Error}",
                            error.SnipLevel, error.Segment, error.SegmentPosition, error.ErrorMessage);
                    }
                }
                else
                {
                    _logger.LogDebug(
                        "Transaction {ControlNumber} in {SourceFileName} passed SNIP validation.",
                        controlNumber,
                        sourceFileName
                    );
                }

                results.Add(new EdiParseResult
                {
                    Transaction              = transaction,
                    TransactionControlNumber = controlNumber,
                    InterchangeControlNumber = currentIsaControlNumber,
                    GroupControlNumber       = currentGsControlNumber,
                    SourceFileName           = sourceFileName,
                    IsValid                  = isValid,
                    ValidationErrors         = errors.AsReadOnly(),
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Unexpected error processing EDI item in {SourceFileName}. Item type: {ItemType}. Skipping.",
                    sourceFileName,
                    item?.GetType().Name ?? "unknown"
                );
            }
        }

        _logger.LogInformation(
            "Completed parse for {SourceFileName}: {ValidCount} valid, {InvalidCount} invalid.",
            sourceFileName,
            results.Count(r => r.IsValid),
            results.Count(r => !r.IsValid)
        );

        return results;
    }
}
