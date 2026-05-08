using EdiFabric.Templates.Hipaa5010;

namespace X12EDI837.Ingestion.Services;

// Structured representation of a single SNIP validation error from EdiFabric.

public sealed record SnipError(
    int    SnipLevel,
    string Segment,
    int?   SegmentPosition,
    string ErrorMessage
);


// Holds a single parsed 837P transaction together with any SNIP validation errors
// that were detected by EdiFabric.

public sealed class EdiParseResult
{
    // The raw EdiFabric transaction model.
    public TS837P Transaction { get; init; } = null!;

    // ST02 – transaction set control number, used as a unique key.
    public string TransactionControlNumber { get; init; } = string.Empty;

    // ISA13 – interchange control number from the enclosing ISA envelope.
    public string InterchangeControlNumber { get; init; } = string.Empty;

    // GS06 – group control number from the enclosing GS envelope.
    public string GroupControlNumber { get; init; } = string.Empty;

    // Name/key of the file the transaction was read from.
    public string SourceFileName { get; init; } = string.Empty;

    // True when EdiFabric found no SNIP violations; false when one or more errors are present in ValidationErrors.
    public bool IsValid { get; init; }

    // Structured list of SNIP violations returned by EdiFabric.
    // Each entry carries the SNIP level, segment name, position, and message.
    // Empty when IsValid is true.
    public IReadOnlyList<SnipError> ValidationErrors { get; init; } = [];
}
