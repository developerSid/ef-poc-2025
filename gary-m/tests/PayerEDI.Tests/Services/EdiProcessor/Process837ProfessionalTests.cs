using PayerEDI.Data.Models;
using PayerEDI.Data.Models.Claims;
using PayerEDI.Tests.Fixtures;

namespace PayerEDI.Tests.Services.EdiProcessor;

public class Process837ProfessionalTests
    : IClassFixture<TestLoggingFixture>,
        IClassFixture<TestEdiFabricFixture>
{
    private readonly Data.Services.EdiProcessor _processor;

    public Process837ProfessionalTests(
        TestLoggingFixture logging,
        TestEdiFabricFixture testEdiFabricFixture
    )
    {
        _ = testEdiFabricFixture;
        _processor = new Data.Services.EdiProcessor(
            logging.CreateLogger<Data.Services.EdiProcessor>()
        );
    }

    [Fact]
    public void Process837ProfessionalAll()
    {
        var samplePath = Path.Combine(
            AppContext.BaseDirectory,
            "samples",
            "EDI",
            "837P-all-fields.edi"
        );

        using var ediStream = File.OpenRead(samplePath);

        var claims = _processor.ProcessEdi(ediStream);

        Assert.NotEmpty(claims);
        Assert.Single(claims);
        var firstClaim = claims[0];

        Assert.IsType<ProfessionalCareClaim>(firstClaim);
        Assert.NotNull(firstClaim);

        ProfessionalCareClaim professionalCareClaim = (firstClaim as ProfessionalCareClaim)!;

        Assert.Equal(DateOnly.Parse("2006-10-15"), professionalCareClaim.TransactionDate);
        Assert.Equal(TimeOnly.Parse("17:05"), professionalCareClaim.TransactionTime);

        // test submitter
        Assert.Equal("41", professionalCareClaim.Submitter.Submitter.EntityIdentifierCode);
        Assert.IsType<ClaimSubmitter>(professionalCareClaim.Submitter);
        NonPerson submitter = (NonPerson)professionalCareClaim.Submitter.Submitter;
        Assert.Equal("PREMIER BILLING SERVICE", submitter.OrganizationName);
        Assert.Null(submitter.AdditionalOrganizationName);
        Assert.Equal("41", submitter.EntityIdentifierCode);
        Assert.Equal("46", submitter.IdentificationCodeQualifier);
        Assert.Equal("TGJ23", submitter.ResponseContactIdentifier);

        // test admin comm contact
        Assert.NotNull(professionalCareClaim.Submitter.AdministrativeCommunicationsContact);
        Assert.Single(professionalCareClaim.Submitter.AdministrativeCommunicationsContact);
        CommunicationsContact communicationsContact = professionalCareClaim
            .Submitter
            .AdministrativeCommunicationsContact[0];
        Assert.Equal("IC", communicationsContact.ContactFunctionCode);
        Assert.Equal("JERRY", communicationsContact.Name);
        Assert.NotNull(communicationsContact.PrimaryNumber);
        Assert.Equal("3055552222", communicationsContact.PrimaryNumber.Number);
        Assert.Equal(
            CommunicationNumberQualifier.Telephone,
            communicationsContact.PrimaryNumber.Qualifier
        );
        Assert.NotNull(communicationsContact.SecondaryNumber);
        Assert.Equal("231", communicationsContact.SecondaryNumber.Number);
        Assert.Equal(
            CommunicationNumberQualifier.TelephoneExtension,
            communicationsContact.SecondaryNumber.Qualifier
        );
        Assert.Null(communicationsContact.TertiaryNumber);

        // test receiver
        Assert.NotNull(professionalCareClaim.Receiver);
        Assert.IsType<NonPerson>(professionalCareClaim.Receiver);
        NonPerson receiver = (NonPerson)professionalCareClaim.Receiver;
        Assert.Equal("KEY INSURANCE COMPANY", receiver.OrganizationName);
        Assert.Equal("40", receiver.EntityIdentifierCode);
        Assert.Equal("46", receiver.IdentificationCodeQualifier);
        Assert.Equal("66783JJT", receiver.ResponseContactIdentifier);

        // test subscriber
        Assert.NotNull(professionalCareClaim.Subscriber);
        Assert.Single(professionalCareClaim.Subscriber);
        Subscriber subscriber = professionalCareClaim.Subscriber[0];
        Assert.IsType<Person>(subscriber.Primary);
        Person primary = (Person)subscriber.Primary;
        Assert.Equal("IL", primary.EntityIdentifierCode);
        Assert.Equal("SMITH", primary.LastName);
        Assert.Equal("JANE", primary.FirstName);
        Assert.Null(primary.MiddleName);
        Assert.Null(primary.Prefix);
        Assert.Null(primary.Suffix);
        Assert.Equal("MI", primary.IdentificationCodeQualifier);
        Assert.Equal("JS00111223333", primary.ResponseContactIdentifier);
        Assert.Null(primary.Relationship);

        // test dependent
        Assert.NotNull(subscriber.Dependents);
        Assert.Single(subscriber.Dependents);
        Assert.IsType<Person>(subscriber.Dependents[0]);
        Person dependent = (Person)subscriber.Dependents[0];
        Assert.Equal("QC", dependent.EntityIdentifierCode);
        Assert.Equal("SMITH", dependent.LastName);
        Assert.Equal("TED", dependent.FirstName);
        Assert.Null(dependent.MiddleName);
        Assert.Null(dependent.Prefix);
        Assert.Null(dependent.Suffix);
        Assert.Null(dependent.IdentificationCodeQualifier);
        Assert.Null(dependent.ResponseContactIdentifier);
        Assert.Null(dependent.Relationship);
    }
}
