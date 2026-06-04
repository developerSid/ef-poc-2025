namespace X12EDI837.Ingestion.Domain;

/// <summary>
/// Represents one service line (LX + SV1 segments).
/// </summary>
public class ServiceLine
{
    public int Id { get; set; }

    // FK
    public int ClaimId { get; set; }
    public Claim Claim { get; set; } = null!;

    // LX01 – line counter (1, 2, 3 …)
    public int LineNumber { get; set; }

    // SV1 fields
    public string ProcedureCode { get; set; } = string.Empty;  // SV101-2 (CPT/HCPCS)
    public string Modifier1 { get; set; } = string.Empty;      // SV101-3
    public string Modifier2 { get; set; } = string.Empty;      // SV101-4
    public decimal LineChargeAmount { get; set; }              // SV102
    public string UnitOfMeasure { get; set; } = string.Empty;  // SV103
    public decimal Quantity { get; set; }                      // SV104
    public string DiagnosisCodePointer { get; set; } = string.Empty; // SV107 (e.g., "1:2")

    // DTP*472 – date of service
    public DateTime? ServiceDate { get; set; }
}
