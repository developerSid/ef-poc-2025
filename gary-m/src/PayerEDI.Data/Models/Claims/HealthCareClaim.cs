namespace PayerEDI.Data.Models.Claims;

/// <summary>
/// Generic EDI 837 - https://www.stedi.com/edi/x12-005010/837
/// </summary>
/// <param name="TransactionDate">Date that the 837 was submitted. I question what this actually is</param>
/// <param name="TransactionTime">Time that the 837 was submitted. I also question what this actually is</param>
public abstract record HealthCareClaim(DateOnly TransactionDate, TimeOnly TransactionTime);

/// <summary>
/// 837P - Professional Health Care Claim
/// </summary>
/// <param name="Id">Our Unique ID or Primary Key - I don't know how I would make that work though</param>
/// <param name="TransactionDate">Date that the 837 was submitted. I question what this actually is</param>
/// <param name="TransactionTime">Time that the 837 was submitted. I also question what this actually is</param>
/// <param name="Submitter">1000A Loop</param>
/// <param name="AdministrativeCommunicationsContact">1000B Loop</param>
/// <param name="Receiver">2010AA</param>
public record ProfessionalCareClaim(
    Guid Id,
    DateOnly TransactionDate,
    TimeOnly TransactionTime,
    IndividualOrOrganization? Submitter,
    IList<CommunicationsContact> AdministrativeCommunicationsContact,
    IndividualOrOrganization? Receiver
) : HealthCareClaim(TransactionDate, TransactionTime);

/// <summary>
/// 837D - Dental Health Care Claim
/// </summary>
/// <param name="Id">Our Unique ID or Primary Key - I don't know how I would make that work though</param>
/// <param name="TransactionDate">Date that the 837 was submitted. I question what this actually is</param>
/// <param name="TransactionTime">Time that the 837 was submitted. I also question what this actually is</param>
/// <param name="Submitter">1000A Loop</param>
/// <param name="AdministrativeCommunicationsContact">1000B Loop</param>
/// <param name="Receiver">2010AA</param>
public sealed record DentalCareClaim(
    Guid Id,
    DateOnly TransactionDate,
    TimeOnly TransactionTime,
    IndividualOrOrganization? Submitter,
    IList<CommunicationsContact> AdministrativeCommunicationsContact,
    IndividualOrOrganization? Receiver
) : HealthCareClaim(TransactionDate, TransactionTime);
