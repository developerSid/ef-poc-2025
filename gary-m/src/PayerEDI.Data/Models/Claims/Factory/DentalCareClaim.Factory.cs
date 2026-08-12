using System.Globalization;
using EdiFabric.Templates.Hipaa5010;
using PayerEDI.Data.Models.Factory;

namespace PayerEDI.Data.Models.Claims.Factory;

public static class DentalCareClaimFactory
{
    private static readonly string[] ClaimDateFormat = ["yyyyMMdd", "yyMMdd"];
    private static readonly string[] ClaimTimeFormat = ["HHmm", "HHmmss", "HHmmssf", "HHmmssff"];

    extension(DentalCareClaim)
    {
        public static DentalCareClaim New(string claimDate, string claimTime, TS837D claim)
        {
            if (string.IsNullOrWhiteSpace(claimDate) || string.IsNullOrWhiteSpace(claimTime))
            {
                throw new ArgumentException(
                    "Claim Date and Claim Time are required and cannot be empty."
                );
            }

            if (
                DateOnly.TryParseExact(
                    claimDate,
                    ClaimDateFormat,
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out var date
                )
                && TimeOnly.TryParseExact(
                    claimTime,
                    ClaimTimeFormat,
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out var time
                )
            )
            {
                var submitter = IndividualOrOrganization.NewSubmitter(
                    claim.AllNM1.Loop1000A.NM1_SubmitterName
                );
                var administrativeCommunicationsContact = CommunicationsContact.New(
                    claim.AllNM1.Loop1000A.PER_SubmitterEDIContactInformation
                );
                var receiver = IndividualOrOrganization.NewReceiver(
                    claim.AllNM1.Loop1000B.NM1_ReceiverName
                );

                return new DentalCareClaim(
                    Id: Guid.CreateVersion7(),
                    TransactionDate: date,
                    TransactionTime: time,
                    Submitter: submitter,
                    AdministrativeCommunicationsContact: administrativeCommunicationsContact,
                    Receiver: receiver
                );
            }

            throw new ArgumentException(
                $"Claim Date must be formatted {ClaimDateFormat} as and claimTime must be formatted {ClaimDateFormat}"
            );
        }
    }
}
