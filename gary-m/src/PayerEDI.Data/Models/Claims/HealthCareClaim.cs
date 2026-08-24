namespace PayerEDI.Data.Models.Claims;

/// <summary>
/// Generic EDI 837 - https://www.stedi.com/edi/x12-005010/837
/// </summary>
/// <param name="TransactionDateTime">Date and time that the 837 was submitted. I question what this actually is</param>
/// <param name="Submitter">1000A Loop & PER Segment - Entity submitting the claim AKA Doctor's office or their Billing Service</param>
/// <param name="Receiver">1000B Loop - The final destination or clearinghouse receiving the professional claim</param>
public abstract record HealthCareClaim(
    DateTime TransactionDateTime,
    ClaimSubmitter Submitter,
    IndividualOrOrganization Receiver
);

/// <summary>
/// 837P - Professional Health Care Claim
/// </summary>
/// <param name="Id">Our Unique ID or Primary Key - I don't know how I would make that work though</param>
/// <param name="TransactionDateTime">Date and time that the 837 was submitted. I question what this actually is</param>
/// <param name="Submitter">1000A Loop & PER Segment - Entity submitting the claim AKA Doctor's office or their Billing Service</param>
/// <param name="Receiver">1000B Loop - The final destination or clearinghouse receiving the professional claim</param>
public sealed record ProfessionalCareClaim(
    DateTime TransactionDateTime,
    ClaimSubmitter Submitter,
    IndividualOrOrganization Receiver,
    IList<Subscriber> Subscribers,
    IList<HealthcareProvider> HealthcareProviders,
    IList<Procedure> Procedures
) : HealthCareClaim(TransactionDateTime, Submitter, Receiver);

/// <summary>
/// 837D - Dental Health Care Claim
/// </summary>
/// <param name="Id">Our Unique ID or Primary Key - I don't know how I would make that work though</param>
/// <param name="TransactionDateTime">Date and time that the 837 was submitted. I question what this actually is</param>
/// <param name="Submitter">1000A Loop & PER Segment - Entity submitting the claim AKA Doctor's office or their Billing Service</param>
/// <param name="Receiver">1000B Loop - The final destination or clearinghouse receiving the professional claim</param>
public sealed record DentalCareClaim(
    DateTime TransactionDateTime,
    ClaimSubmitter Submitter,
    IndividualOrOrganization Receiver,
    IList<Subscriber> Subscribers,
    IList<HealthcareProvider> HealthcareProviders,
    IList<Procedure> Procedures
) : HealthCareClaim(TransactionDateTime, Submitter, Receiver);
