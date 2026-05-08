namespace X12EDI837.Ingestion.Domain;

/// <summary>
/// Stores a single SNIP validation error returned by EdiFabric for a claim.
/// Persisting these enables reprocessing, auditing, and payer-specific reporting.
/// </summary>
public class SnipValidationError
{
    public int Id { get; set; }

    // FK
    public int ClaimId { get; set; }
    public Claim Claim { get; set; } = null!;

    /// <summary>SNIP level where the error occurred (1–8).</summary>
    public int SnipLevel { get; set; }

    /// <summary>Segment name that triggered the error (e.g., "CLM", "SV1").</summary>
    public string Segment { get; set; } = string.Empty;

    /// <summary>Human-readable error description from EdiFabric.</summary>
    public string ErrorMessage { get; set; } = string.Empty;

    /// <summary>EDI position (segment index) within the transaction set.</summary>
    public int? SegmentPosition { get; set; }

    public DateTime RecordedAt { get; set; } = DateTime.UtcNow;
}
