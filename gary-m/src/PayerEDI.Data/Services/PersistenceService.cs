using EdiFabric.Core.Model.Edi.ErrorContexts;
using EdiFabric.Templates.Hipaa5010;
using FastEnumUtility;
using PayerEDI.Data.Database;
using PayerEDI.Data.Database.Repositories;
using PayerEDI.Data.Database.Tables;
using PayerEDI.Data.Helpers;
using PayerEDI.Data.Models;
using PayerEDI.Data.Models.Claims;

namespace PayerEDI.Data.Services;

public class PersistenceService(
    PayerEdiDbContext context,
    IDocumentTableRepository documentTableRepository,
    IPatientRepository patientRepository
) : IPersistenceService
{
    public Task Save(
        TS837P ts837P,
        ProfessionalCareClaim professionalCareClaim,
        CancellationToken cancellationToken = default
    ) =>
        SaveClaimAsync(
            ts837P.CreateDocument(),
            GetPatients(professionalCareClaim.Subscribers),
            ts837P.ErrorContext,
            cancellationToken
        );

    public Task Save(
        TS837D ts837D,
        DentalCareClaim dentalCareClaim,
        CancellationToken cancellationToken = default
    ) =>
        SaveClaimAsync(
            ts837D.CreateDocument(),
            GetPatients(dentalCareClaim.Subscribers),
            ts837D.ErrorContext,
            cancellationToken
        );

    public async Task<DocumentTable> Save(
        TS837P ts837P,
        CancellationToken cancellationToken = default
    )
    {
        var documentTable = ts837P.CreateDocument();

        await documentTableRepository.SaveAsync(documentTable, cancellationToken);
        return documentTable;
    }

    public async Task<DocumentTable> Save(
        TS837D ts837D,
        CancellationToken cancellationToken = default
    )
    {
        var documentTable = ts837D.CreateDocument();

        await documentTableRepository.SaveAsync(documentTable, cancellationToken);
        return documentTable;
    }

    public async Task<IReadOnlyCollection<PatientTable>> Save(
        ProfessionalCareClaim professionalCareClaim,
        CancellationToken cancellationToken = default
    )
    {
        var patients = GetPatients(professionalCareClaim.Subscribers);
        await patientRepository.SaveAsync(patients, cancellationToken);
        return patients;
    }

    public async Task<IReadOnlyCollection<PatientTable>> Save(
        DentalCareClaim dentalCareClaim,
        CancellationToken cancellationToken = default
    )
    {
        var patients = GetPatients(dentalCareClaim.Subscribers);
        await patientRepository.SaveAsync(patients, cancellationToken);
        return patients;
    }

    private static IReadOnlyCollection<PatientTable> GetPatients(
        IEnumerable<Subscriber> subscribers
    ) =>
        subscribers
            .SelectMany(subscriber => new[] { subscriber.Primary }.Concat(subscriber.Dependents))
            .Select(ToPatientTable)
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

    private static PatientTable ToPatientTable(IndividualOrOrganization entity) =>
        entity switch
        {
            Person person => new PatientTable
            {
                EntityType = nameof(Person),
                EntityIdentifierCode = person.EntityIdentifierCode,
                IdentificationCodeQualifier = person.IdentificationCodeQualifier,
                ResponseContactIdentifier = person.ResponseContactIdentifier,
                LastName = person.LastName,
                SecondLastName = person.SecondLastName,
                FirstName = person.FirstName,
                MiddleName = person.MiddleName,
                Prefix = person.Prefix,
                Suffix = person.Suffix,
                Relationship = person.Relationship?.GetEnumMemberValue(),
            },
            NonPerson nonPerson => new PatientTable
            {
                EntityType = nameof(NonPerson),
                EntityIdentifierCode = nonPerson.EntityIdentifierCode,
                IdentificationCodeQualifier = nonPerson.IdentificationCodeQualifier,
                ResponseContactIdentifier = nonPerson.ResponseContactIdentifier,
                OrganizationName = nonPerson.OrganizationName,
                AdditionalOrganizationName = nonPerson.AdditionalOrganizationName,
                Relationship = nonPerson.Relationship?.GetEnumMemberValue(),
            },
            _ => throw new ArgumentOutOfRangeException(
                nameof(entity),
                entity,
                "Unsupported entity type."
            ),
        };
}
