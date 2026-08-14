namespace PayerEDI.Data.Models;

public record ClaimSubmitter(
    IndividualOrOrganization Submitter,
    IList<CommunicationsContact> AdministrativeCommunicationsContact
);
