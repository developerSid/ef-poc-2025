using System.Reflection;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;
using EdiFabric.Templates.Hipaa5010;
using PayerEDI.Data.Database.Repositories;
using PayerEDI.Data.Database.Tables;
using PayerEDI.Data.Models;
using PayerEDI.Data.Models.Claims;

namespace PayerEDI.Data.Services;

public class PersistenceService(
    DocumentTableRepository documentTableRepository,
    PatientRepository patientRepository
)
{
    public async Task<DocumentTable> Save(
        TS837P ts837P,
        CancellationToken cancellationToken = default
    )
    {
        var documentTable = new DocumentTable
        {
            EdiMessageType = nameof(TS837P),
            Xml = SerializeXml(ts837P),
        };

        await documentTableRepository.SaveAsync(documentTable, cancellationToken);
        return documentTable;
    }

    public async Task<DocumentTable> Save(
        TS837D ts837D,
        CancellationToken cancellationToken = default
    )
    {
        var documentTable = new DocumentTable
        {
            EdiMessageType = nameof(TS837D),
            Xml = SerializeXml(ts837D),
        };

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
                Relationship = GetEnumMemberValue(person.Relationship),
            },
            NonPerson nonPerson => new PatientTable
            {
                EntityType = nameof(NonPerson),
                EntityIdentifierCode = nonPerson.EntityIdentifierCode,
                IdentificationCodeQualifier = nonPerson.IdentificationCodeQualifier,
                ResponseContactIdentifier = nonPerson.ResponseContactIdentifier,
                OrganizationName = nonPerson.OrganizationName,
                AdditionalOrganizationName = nonPerson.AdditionalOrganizationName,
                Relationship = GetEnumMemberValue(nonPerson.Relationship),
            },
            _ => throw new ArgumentOutOfRangeException(
                nameof(entity),
                entity,
                "Unsupported entity type."
            ),
        };

    private static string? GetEnumMemberValue<TEnum>(TEnum? value)
        where TEnum : struct, Enum
    {
        if (value is not { } enumValue)
        {
            return null;
        }

        return typeof(TEnum)
            .GetField(enumValue.ToString())
            ?.GetCustomAttribute<EnumMemberAttribute>()
            ?.Value;
    }

    private static string SerializeXml<T>(T value)
    {
        var serializer = new XmlSerializer(value is null ? typeof(T) : value.GetType());
        var settings = new XmlWriterSettings { Indent = true, OmitXmlDeclaration = true };

        using var stringWriter = new StringWriter();
        using var xmlWriter = XmlWriter.Create(stringWriter, settings);
        serializer.Serialize(xmlWriter, value);

        return stringWriter.ToString();
    }
}
