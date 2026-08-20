using EdiFabric.Templates.Hipaa5010;
using PayerEDI.Data.Database.Tables;
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

    Task<DocumentTable> Save(TS837P ts837P, CancellationToken cancellationToken = default);

    Task<DocumentTable> Save(TS837D ts837D, CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<PatientTable>> Save(
        ProfessionalCareClaim professionalCareClaim,
        CancellationToken cancellationToken = default
    );

    Task<IReadOnlyCollection<PatientTable>> Save(
        DentalCareClaim dentalCareClaim,
        CancellationToken cancellationToken = default
    );
}
