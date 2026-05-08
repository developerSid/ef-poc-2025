namespace X12EDI837.Ingestion.Domain;

/// <summary>
/// Represents the billing provider (NM1*85 loop).
/// </summary>
public class BillingProvider
{
    public int Id { get; set; }

    // FK back to claim
    public int ClaimId { get; set; }
    public Claim Claim { get; set; } = null!;

    // NM1 fields
    public string Npi { get; set; } = string.Empty;            // NM109 – provider NPI
    public string OrganizationName { get; set; } = string.Empty; // NM103 (if entity type = 2)
    public string LastName { get; set; } = string.Empty;       // NM103 (if entity type = 1)
    public string FirstName { get; set; } = string.Empty;      // NM104
    public string TaxonomyCode { get; set; } = string.Empty;   // PRV03

    // N3 / N4
    public string AddressLine1 { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string Zip { get; set; } = string.Empty;
}
