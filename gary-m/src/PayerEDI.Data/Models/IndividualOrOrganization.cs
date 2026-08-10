using EdiFabric.Templates.Hipaa5010;

namespace PayerEDI.Data.Models;

// NM1 segment definition -> https://www.stedi.com/edi/x12-005010/segment/NM1

/// <summary>
/// Common identity data mapped from an X12 NM1 segment.
/// </summary>
/// <remarks>
/// <para>
/// NM101 identifies the entity's role in the transaction. NM108 qualifies the
/// identifier stored in NM109; the qualifier must be retained because the same
/// identifier field can contain an NPI, member identifier, tax identifier,
/// submitter identifier, or another identifier type depending on the code.
/// </para>
/// <para>
/// The NM1 factory methods require NM101, NM102, NM103, NM108, and NM109 to be
/// present and non-blank. They trim accepted string values and throw
/// <see cref="InvalidNm1Exception"/> when a required value is missing or when
/// NM102 contains an unsupported entity type. Optional name fields and NM110
/// relationship data remain nullable.
/// </para>
/// <para>
/// NM102 value <c>1</c> creates a <see cref="Person"/>; value <c>2</c> creates a
/// <see cref="NonPerson"/>. NM110 is converted to
/// <see cref="EntityRelationshipCode"/> when its code is recognized.
/// </para>
/// </remarks>
public abstract record IndividualOrOrganization(
    string EntityIdentifierCode,
    string IdentificationCodeQualifier,
    string ResponseContactIdentifier
);

/// <summary>
/// NM1 - NM102. Entity Type Qualifier code = 1 for a person entity.
/// </summary>
/// <remarks>
/// Represents an individual person identified by the shared NM1 segment fields.
/// </remarks>
/// <param name="EntityIdentifierCode">NM1-01: Entity Identifier Code identifying the person's role in the transaction.</param>
/// <param name="LastName">NM1-03: Primary Name Last or Organization Name. For a person, this is the person's primary last name. NM103 is required when NM112 is present.</param>
/// <param name="SecondLastName">NM1-12: Additional Name Last or Organization Name. For a person, this may contain a second surname.</param>
/// <param name="FirstName">NM1-04: Optional Name First value.</param>
/// <param name="MiddleName">NM1-05: Optional Name Middle value.</param>
/// <param name="Prefix">NM1-06: Optional Name Prefix value.</param>
/// <param name="Suffix">NM1-07: Optional Name Suffix value.</param>
/// <param name="IdentificationCodeQualifier">NM1-08: Identification Code Qualifier describing the type of identifier stored in NM109.</param>
/// <param name="ResponseContactIdentifier">NM1-09: Identification Code identifying the person. NM108 and NM109 are required together.</param>
/// <param name="Relationship">NM1-10: Entity Relationship Code describing the person's relationship to the NM101 entity. It is nullable when NM110 is absent or not recognized.</param>
public sealed record Person(
    string EntityIdentifierCode,
    string LastName,
    string? SecondLastName,
    string? FirstName,
    string? MiddleName,
    string? Prefix,
    string? Suffix,
    string IdentificationCodeQualifier,
    string ResponseContactIdentifier,
    EntityRelationshipCode? Relationship
)
    : IndividualOrOrganization(
        EntityIdentifierCode,
        IdentificationCodeQualifier,
        ResponseContactIdentifier
    );

/// <summary>
/// NM1 - NM102. Entity Type Qualifier code = 2 for a non-person entity, such as a corporation.
/// </summary>
/// <remarks>
/// Represents a non-person entity such as a corporation, facility, payer, or other organization.
/// The values are mapped from the shared NM1 segment fields used to identify the entity.
/// </remarks>
/// <param name="EntityIdentifierCode">NM1-01: Entity Identifier Code identifying the organization's role in the transaction.</param>
/// <param name="OrganizationName">NM1-03: Primary Name Last or Organization Name. For a non-person entity, this is the organization's primary name. NM103 is required when NM112 is present.</param>
/// <param name="AdditionalOrganizationName">NM1-12: Additional Name Last or Organization Name. For a non-person entity, this may contain a secondary or overflow organization name.</param>
/// <param name="IdentificationCodeQualifier">NM1-08: Identification Code Qualifier describing the type of identifier stored in NM109.</param>
/// <param name="ResponseContactIdentifier">NM1-09: Identification Code identifying the organization or other entity. NM108 and NM109 are required together.</param>
/// <param name="Relationship">NM1-10: Entity Relationship Code describing the entity's relationship to the NM101 entity. It is nullable when NM110 is absent or not recognized. C1110: If NM1-11 is present, then NM1-10 is required</param>
public sealed record NonPerson(
    string EntityIdentifierCode,
    string OrganizationName,
    string? AdditionalOrganizationName,
    string IdentificationCodeQualifier,
    string ResponseContactIdentifier,
    EntityRelationshipCode? Relationship
)
    : IndividualOrOrganization(
        EntityIdentifierCode,
        IdentificationCodeQualifier,
        ResponseContactIdentifier
    );

public sealed class InvalidNm1Exception(string message) : InvalidOperationException(message);

// TODO: Put the extensions in separate file maybe?
public static class PersonExtensions
{
    extension(Person)
    {
        public static Person New(NM1 receiverName) =>
            new(
                EntityIdentifierCode: receiverName.EntityIdentifierCode_01.RequireNm1("NM101"),
                LastName: receiverName.ResponseContactLastorOrganizationName_03.RequireNm1("NM103"),
                SecondLastName: receiverName.NameLastorOrganizationName_12,
                FirstName: receiverName.ResponseContactFirstName_04,
                MiddleName: receiverName.ResponseContactMiddleName_05,
                Prefix: receiverName.NamePrefix_06,
                Suffix: receiverName.ResponseContactNameSuffix_07,
                IdentificationCodeQualifier: receiverName.IdentificationCodeQualifier_08.RequireNm1(
                    "NM108"
                ),
                ResponseContactIdentifier: receiverName.ResponseContactIdentifier_09.RequireNm1(
                    "NM109"
                ),
                Relationship: EntityRelationshipCode.FromCode(
                    receiverName.EntityRelationshipCode_10
                )
            );
    }
}

public static class NonPersonExtensions
{
    extension(NonPerson)
    {
        public static NonPerson New(NM1 receiverName) =>
            new(
                EntityIdentifierCode: receiverName.EntityIdentifierCode_01.RequireNm1("NM101"),
                OrganizationName: receiverName.ResponseContactLastorOrganizationName_03.RequireNm1(
                    "NM103"
                ), // Individual last name or organizational name, NM112 is present then NM103 is required
                AdditionalOrganizationName: receiverName.NameLastorOrganizationName_12, // C1203: If NM1-12 is present, then NM1-03 is required, NM112 can identify a second surname.
                IdentificationCodeQualifier: receiverName.IdentificationCodeQualifier_08.RequireNm1(
                    "NM108"
                ), // P0809: If either NM1-08 or NM1-09 is present, then the other is required
                ResponseContactIdentifier: receiverName.ResponseContactIdentifier_09.RequireNm1(
                    "NM109"
                ), // NM109 - Code identifying a party or other code
                Relationship: EntityRelationshipCode.FromCode(
                    receiverName.EntityRelationshipCode_10
                ) // NM110 - Code describing entity relationship
            );
    }
}

public static class IndividualOrOrganizationExtensions
{
    extension(IndividualOrOrganization)
    {
        private static IndividualOrOrganization NewNm1(NM1 nm1) => // keeping this private for now to make a more readable API call
            nm1.EntityTypeQualifier_02.RequireNm1("NM102").Trim() switch // Note: there are 16 codes, 1 and 2 are for my naive implementation. See: https://www.stedi.com/edi/x12-005010/segment/NM1#NM1-02
            {
                "1" => Person.New(nm1),
                "2" => NonPerson.New(nm1),
                _ => throw new InvalidNm1Exception(
                    $"entity type qualifier {nm1.EntityTypeQualifier_02} not handled"
                ),
            };

        public static IndividualOrOrganization NewSubmitter(
            NM1_InformationReceiverName_4 submitterName // from what I can tell even though it has Receiver in the name this is the submitter name property
        ) => IndividualOrOrganization.NewNm1(submitterName);

        public static IndividualOrOrganization NewReceiver(NM1_ReceiverName receiverName) =>
            IndividualOrOrganization.NewNm1(receiverName); // see above comment, but keep in mind this seems less dumb
    }
}

/// <summary>
/// AI generated validation.  I can't say that I like it much, but at least the ternary code is duped all over the place
/// I do feel like there is a more robust rules way of handling a field, and it's related fields being handled to get a
/// richer set of errors
/// </summary>
internal static class Nm1ValidationExtensions
{
    public static string RequireNm1(this string? value, string element) => // this is a very naive implementation
        string.IsNullOrWhiteSpace(value)
            ? throw new InvalidNm1Exception($"{element} is required for an NM1 identity.")
            : value.Trim();
}
