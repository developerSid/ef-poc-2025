namespace X12EDI837.Ingestion.Domain;

/// <summary>
/// Represents one diagnosis code from the HI segment.
/// </summary>
public class DiagnosisCode
{
    public int Id { get; set; }

    // FK
    public int ClaimId { get; set; }
    public Claim Claim { get; set; } = null!;

    // Sequence within the claim (1 = principal)
    public int SequenceNumber { get; set; }

    // HI01-1 qualifier (e.g. "ABK" = ICD-10 principal, "ABF" = ICD-10 other)
    public string Qualifier { get; set; } = string.Empty;

    // HI01-2 the actual ICD-10 code (e.g. "J18.9")
    public string Code { get; set; } = string.Empty;
}
