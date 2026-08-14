namespace PayerEDI.Data.Models.Claims;

/// <summary>
/// Generic EDI 837 - https://www.stedi.com/edi/x12-005010/837
/// </summary>
/// <param name="TransactionDate">Date that the 837 was submitted. I question what this actually is</param>
/// <param name="TransactionTime">Time that the 837 was submitted. I also question what this actually is</param>
/// <param name="Submitter">1000A Loop & PER Segment - Entity submitting the claim AKA Doctor's office or their Billing Service</param>
/// <param name="Receiver">1000B Loop - The final destination or clearinghouse receiving the professional claim</param>
public abstract record HealthCareClaim(
    DateOnly TransactionDate,
    TimeOnly TransactionTime,
    ClaimSubmitter Submitter,
    IndividualOrOrganization Receiver
);

/// <summary>
/// Placeholder for an unknown claim as yet TBD, use wisely
/// </summary>
/// <param name="Claim">The claim we haven't handled yet</param>
public sealed record UnknownClaim(HealthCareClaim Claim);

/// <summary>
/// 837P - Professional Health Care Claim
/// </summary>
/// <param name="Id">Our Unique ID or Primary Key - I don't know how I would make that work though</param>
/// <param name="TransactionDate">Date that the 837 was submitted. I question what this actually is</param>
/// <param name="TransactionTime">Time that the 837 was submitted. I also question what this actually is</param>
/// <param name="Submitter">1000A Loop & PER Segment - Entity submitting the claim AKA Doctor's office or their Billing Service</param>
/// <param name="Receiver">1000B Loop - The final destination or clearinghouse receiving the professional claim</param>
public record ProfessionalCareClaim(
    Guid Id,
    DateOnly TransactionDate,
    TimeOnly TransactionTime,
    ClaimSubmitter Submitter,
    IndividualOrOrganization Receiver
// Providers - Doctors or similar medical operators doing medical work
// Patient
// procedures
) : HealthCareClaim(TransactionDate, TransactionTime, Submitter, Receiver);

/// <summary>
/// 837D - Dental Health Care Claim
/// </summary>
/// <param name="Id">Our Unique ID or Primary Key - I don't know how I would make that work though</param>
/// <param name="TransactionDate">Date that the 837 was submitted. I question what this actually is</param>
/// <param name="TransactionTime">Time that the 837 was submitted. I also question what this actually is</param>
/// <param name="Submitter">1000A Loop & PER Segment - Entity submitting the claim AKA Doctor's office or their Billing Service</param>
/// <param name="Receiver">1000B Loop - The final destination or clearinghouse receiving the professional claim</param>
public sealed record DentalCareClaim(
    Guid Id,
    DateOnly TransactionDate,
    TimeOnly TransactionTime,
    ClaimSubmitter Submitter,
    IndividualOrOrganization Receiver
// Providers - Doctors or similar medical operators doing medical work
// Patient
// procedures
) : HealthCareClaim(TransactionDate, TransactionTime, Submitter, Receiver);
