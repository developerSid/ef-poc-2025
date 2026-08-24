using EdiFabric.Core.Model.Edi.ErrorContexts;
using EdiFabric.Templates.Hipaa5010;
using Microsoft.Extensions.Logging;
using PayerEDI.Data.Database;
using PayerEDI.Data.Database.Repositories;
using PayerEDI.Data.Database.Tables;
using PayerEDI.Data.Models;
using PayerEDI.Data.Models.Claims;

namespace PayerEDI.Data.Services;

public class PersistenceService(
    Logger<PersistenceService> logger,
    PayerEdiDbContext context,
    IDocumentTableRepository documentTableRepository,
    IPatientRepository patientRepository
) : IPersistenceService
{
    public Task Save(
        TS837P ts837P,
        ProfessionalCareClaim professionalCareClaim,
        CancellationToken cancellationToken = default
    )
    {
        logger.LogTrace("Saving professional care claim {Claim}", professionalCareClaim);

        return SaveClaimAsync(
            ts837P.CreateDocument(professionalCareClaim.TransactionDateTime),
            GetPatients(professionalCareClaim.Subscribers),
            ts837P.ErrorContext,
            cancellationToken
        );
    }

    public Task Save(
        TS837D ts837D,
        DentalCareClaim dentalCareClaim,
        CancellationToken cancellationToken = default
    )
    {
        logger.LogTrace("Saving dental care claim {Claim}", dentalCareClaim);

        return SaveClaimAsync(
            ts837D.CreateDocument(dentalCareClaim.TransactionDateTime),
            GetPatients(dentalCareClaim.Subscribers),
            ts837D.ErrorContext,
            cancellationToken
        );
    }

    private static PatientTable[] GetPatients( // TODO: page this somehow
        IEnumerable<Subscriber> subscribers
    ) =>
        subscribers
            .SelectMany(subscriber => new[] { subscriber.Primary }.Concat(subscriber.Dependents))
            .Select(PatientTable.ToPatientTable)
            .ToArray();

    private async Task SaveClaimAsync(
        DocumentTable documentTable,
        IReadOnlyCollection<PatientTable> patients,
        MessageErrorContext? errorContext,
        CancellationToken cancellationToken
    )
    {
        // Keep the document and its patients atomic: a failed claim must not leave only half of
        // its records persisted. The transaction also uses this scope's single DbContext instance.
        await using var transaction = await context.Database.BeginTransactionAsync( // this is how EF Core handles transactions, Spring does this with an annotation on the method
            cancellationToken
        );

        documentTableRepository.Add(documentTable);
        patientRepository.AddRange(patients);
        if (errorContext is not null)
        {
            context.EdiErrors.Add(errorContext.CreateEdiError(documentTable.Id));
        }
        // Add and AddRange only stage both entity sets in the same DbContext; this single
        // SaveChangesAsync call is the only database commit for the entire claim.
        await context.SaveChangesAsync(cancellationToken);
        await transaction.CommitAsync(cancellationToken);
    }
}
