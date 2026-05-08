namespace X12EDI837.Ingestion.Domain;

/// <summary>
/// Represents the subscriber / insured (NM1*IL loop).
/// </summary>
public class Subscriber
{
    public int Id { get; set; }

    // FK back to claim
    public int ClaimId { get; set; }
    public Claim Claim { get; set; } = null!;

    // NM1 segment fields
    public string MemberId { get; set; } = string.Empty;       // NM109 – subscriber ID
    public string LastName { get; set; } = string.Empty;       // NM103
    public string FirstName { get; set; } = string.Empty;      // NM104
    public string MiddleName { get; set; } = string.Empty;     // NM105

    // DMG segment
    public DateTime? DateOfBirth { get; set; }                 // DMG02
    public string Gender { get; set; } = string.Empty;         // DMG03 (M/F/U)

    // N3 / N4
    public string AddressLine1 { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string Zip { get; set; } = string.Empty;
}
