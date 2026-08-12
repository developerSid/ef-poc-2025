using EdiFabric.Templates.Hipaa5010;

namespace PayerEDI.Data.Models.Factory;

public static class PersonFactory
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

public static class NonPersonFactory
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

public static class IndividualOrOrganizationFactory
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
