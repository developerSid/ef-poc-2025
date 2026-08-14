namespace PayerEDI.Data.Models;

public record ClaimSubmitter(
    IndividualOrOrganization Submitter,
    IList<CommunicationsContact> AdministrativeCommunicationsContact,
    ExternalIdentifier ExternalIdentifier
)
{
    public Guid Id { get; init; } = Guid.CreateVersion7();
}
