using PayerEDI.Data.Models;
using PayerEDI.Data.Models.Claims;
using PayerEDI.Tests.Fixtures;

namespace PayerEDI.Tests.Services.EdiProcessor;

public class Process837Dental
    : IClassFixture<TestLoggingFixture>,
        IClassFixture<TestEdiFabricFixture>
{
    private readonly Data.Services.EdiProcessor _processor;

    public Process837Dental(TestLoggingFixture logging, TestEdiFabricFixture testEdiFabricFixture)
    {
        _ = testEdiFabricFixture;
        _processor = new Data.Services.EdiProcessor(
            logging.CreateLogger<Data.Services.EdiProcessor>()
        );
    }

    [Fact]
    public void ProcessSample3()
    {
        var samplePath = Path.Combine(
            AppContext.BaseDirectory,
            "samples",
            "EDI",
            "837d-sample-3.edi"
        );

        using var ediStream = File.OpenRead(samplePath);

        var claims = _processor.ProcessEdi(ediStream);

        Assert.NotEmpty(claims);
        Assert.Single(claims);
        var firstClaim = claims[0];

        Assert.IsType<DentalCareClaim>(firstClaim);
        Assert.NotNull(firstClaim);

        DentalCareClaim dentalCareClaim = (firstClaim as DentalCareClaim)!;

        Assert.Equal(DateOnly.Parse("2008-05-03"), dentalCareClaim.TransactionDate);
        Assert.Equal(TimeOnly.Parse("17:05"), dentalCareClaim.TransactionTime);

        // test submitter
        Assert.Equal("41", dentalCareClaim.Submitter.Submitter.EntityIdentifierCode);
        Assert.IsType<ClaimSubmitter>(dentalCareClaim.Submitter);
        NonPerson submitter = (NonPerson)dentalCareClaim.Submitter.Submitter;
        Assert.Equal("PREMIER BILLING SERVICE", submitter.OrganizationName);
        Assert.Null(submitter.AdditionalOrganizationName);
        Assert.Equal("41", submitter.EntityIdentifierCode);
        Assert.Equal("46", submitter.IdentificationCodeQualifier);
        Assert.Equal("TGJ23", submitter.ResponseContactIdentifier);

        // test admin comm contact
        Assert.NotNull(dentalCareClaim.Submitter.AdministrativeCommunicationsContact);
        Assert.Single(dentalCareClaim.Submitter.AdministrativeCommunicationsContact);
        CommunicationsContact communicationsContact = dentalCareClaim
            .Submitter
            .AdministrativeCommunicationsContact[0];
        Assert.Equal("IC", communicationsContact.ContactFunctionCode);
        Assert.Equal("JERRY", communicationsContact.Name);
        Assert.NotNull(communicationsContact.PrimaryNumber);
        Assert.Equal("7176149999", communicationsContact.PrimaryNumber.Number);
        Assert.Equal(
            CommunicationNumberQualifier.Telephone,
            communicationsContact.PrimaryNumber.Qualifier
        );
        Assert.Null(communicationsContact.SecondaryNumber);
        Assert.Null(communicationsContact.TertiaryNumber);

        // test receiver
        Assert.NotNull(dentalCareClaim.Receiver);
        Assert.IsType<NonPerson>(dentalCareClaim.Receiver);
        NonPerson receiver = (NonPerson)dentalCareClaim.Receiver;
        Assert.Equal("INSURANCE COMPANY XYZ", receiver.OrganizationName);
        Assert.Equal("40", receiver.EntityIdentifierCode);
        Assert.Equal("46", receiver.IdentificationCodeQualifier);
        Assert.Equal("66783JJT", receiver.ResponseContactIdentifier);

        // test subscriber
        Assert.NotNull(dentalCareClaim.Subscriber);
        Assert.Single(dentalCareClaim.Subscriber);
        Subscriber subscriber = dentalCareClaim.Subscriber[0];
        Assert.IsType<Person>(subscriber.Primary);
        Person primary = (Person)subscriber.Primary;
        Assert.Equal("IL", primary.EntityIdentifierCode);
        Assert.Equal("SMITH", primary.LastName);
        Assert.Equal("JANE", primary.FirstName);
        Assert.Null(primary.MiddleName);
        Assert.Null(primary.Prefix);
        Assert.Null(primary.Suffix);
        Assert.Equal("MI", primary.IdentificationCodeQualifier);
        Assert.Equal("111223333", primary.ResponseContactIdentifier);
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
