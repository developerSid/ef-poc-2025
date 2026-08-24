using EdiFabric.Templates.Hipaa5010;
using PayerEDI.Data.Models.Claims;

namespace PayerEDI.Data.Services;

public interface IPersistenceService
{
    Task Save(
        TS837P ts837P,
        ProfessionalCareClaim professionalCareClaim,
        CancellationToken cancellationToken = default
    );

    Task Save(
        TS837D ts837D,
        DentalCareClaim dentalCareClaim,
        CancellationToken cancellationToken = default
    );
}
