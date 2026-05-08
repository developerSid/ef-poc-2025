namespace X12EDI837.Ingestion.Domain;

/// <summary>
/// Represents a single 837P professional claim (CLM segment).
/// </summary>
public class Claim
{
    public int Id { get; set; }

    // --- Interchange / Group identifiers (ISA / GS) ---
    public string InterchangeControlNumber { get; set; } = string.Empty;   // ISA13
    public string GroupControlNumber { get; set; } = string.Empty;         // GS06
    public string TransactionSetControlNumber { get; set; } = string.Empty; // ST02

    // --- CLM01: Claim identifier assigned by submitter ---
    public string ClaimId { get; set; } = string.Empty;

    // --- CLM02: Total claim charge amount ---
    public decimal TotalChargeAmount { get; set; }

    // --- CLM05: Place of service / facility code ---
    public string FacilityTypeCode { get; set; } = string.Empty;

    // --- CLM08: Assignment of benefits (Y/N) ---
    public string AssignmentOfBenefits { get; set; } = string.Empty;

    // --- CLM09: Release of information (Y/I) ---
    public string ReleaseOfInformation { get; set; } = string.Empty;

    // --- Dates ---
    public DateTime? ServiceDateFrom { get; set; }
    public DateTime? ServiceDateTo { get; set; }
    public DateTime IngestedAt { get; set; } = DateTime.UtcNow;

    // --- Source file tracking ---
    public string SourceFileName { get; set; } = string.Empty;

    // --- Validation status ---
    /// <summary>True = passed SNIP validation. False = failed — check SnipValidationErrors for details.</summary>
    public bool IsValid { get; set; } = true;

    /// <summary>Number of SNIP errors. 0 for valid claims.</summary>
    public int SnipErrorCount { get; set; } = 0;

    // --- File source tracking ---
    /// <summary>"local" or "s3" — where the file was ingested from.</summary>
    public string FileSource { get; set; } = string.Empty;

    // --- Navigation ---
    public Subscriber? Subscriber { get; set; }
    public BillingProvider? BillingProvider { get; set; }
    public ICollection<ServiceLine> ServiceLines { get; set; } = new List<ServiceLine>();
    public ICollection<DiagnosisCode> DiagnosisCodes { get; set; } = new List<DiagnosisCode>();
    public ICollection<SnipValidationError> SnipValidationErrors { get; set; } = new List<SnipValidationError>();
}
