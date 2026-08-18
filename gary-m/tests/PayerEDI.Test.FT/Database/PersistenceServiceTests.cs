using EdiFabric.Templates.Hipaa5010;
using Microsoft.EntityFrameworkCore;
using PayerEDI.Data.Database;
using PayerEDI.Data.Database.Repositories;
using PayerEDI.Data.Database.Tables;
using PayerEDI.Data.Models;
using PayerEDI.Data.Models.Claims;
using PayerEDI.Data.Services;
using PayerEDI.Test.FT.Database.Fixtures;

namespace PayerEDI.Test.FT.Database;

public sealed class PersistenceServiceTests(SqlServerFixture fixture)
    : IClassFixture<SqlServerFixture>,
        IAsyncLifetime
{
    public Task InitializeAsync() => fixture.PrepareDatabaseAsync();

    public Task DisposeAsync() => Task.CompletedTask;

    [Fact]
    public async Task Document_rows_persist_through_persistence_service()
    {
        DocumentTable result;
        await using (var context = fixture.CreateContext())
        {
            var service = CreateService(context);
            result = await service.Save(new TS837P());
        }

        Assert.Equal("TS837P", result.EdiMessageType);

        await using var verificationContext = fixture.CreateContext();
        var persistedDocument = await verificationContext.Documents.SingleAsync(item =>
            item.Id == result.Id
        );

        Assert.Equal("TS837P", persistedDocument.EdiMessageType);
        Assert.Contains("TS837P", persistedDocument.Xml);
    }

    [Fact]
    public async Task Professional_claim_persists_subscriber_and_dependents()
    {
        var subscriber = new Person(
            EntityIdentifierCode: "IL",
            LastName: "Doe",
            SecondLastName: null,
            FirstName: "Jane",
            MiddleName: null,
            Prefix: null,
            Suffix: null,
            IdentificationCodeQualifier: "MI",
            ResponseContactIdentifier: "MEMBER-001",
            Relationship: EntityRelationshipCode.Self
        );
        var dependent = new Person(
            EntityIdentifierCode: "QC",
            LastName: "Doe",
            SecondLastName: null,
            FirstName: "Sam",
            MiddleName: null,
            Prefix: null,
            Suffix: null,
            IdentificationCodeQualifier: null,
            ResponseContactIdentifier: null,
            Relationship: EntityRelationshipCode.Child
        );
        var claim = new ProfessionalCareClaim(
            TransactionDate: new DateOnly(2026, 8, 18),
            TransactionTime: new TimeOnly(12, 30),
            Submitter: new ClaimSubmitter(
                subscriber,
                [],
                new ExternalIdentifier("46", "SUBMITTER-001")
            ),
            Receiver: new NonPerson("PR", "Example Payer", null, "PI", "PAYER-001", null),
            Subscribers: [new Subscriber(subscriber, [dependent])],
            HealthcareProviders: []
        );

        await using (var context = fixture.CreateContext())
        {
            var service = CreateService(context);
            var patients = await service.Save(claim);

            Assert.Equal(2, patients.Count);
        }

        await using var verificationContext = fixture.CreateContext();
        var persistedPatients = await verificationContext
            .Patients.OrderBy(item => item.FirstName)
            .ToListAsync();

        Assert.Equal(2, persistedPatients.Count);
        Assert.Equal("Sam", persistedPatients[0].FirstName);
        Assert.Equal("02", persistedPatients[0].Relationship);
        Assert.Equal("Jane", persistedPatients[1].FirstName);
        Assert.Equal("67", persistedPatients[1].Relationship);
        Assert.Equal(1, await verificationContext.Documents.CountAsync());
    }

    private static PersistenceService CreateService(PayerEdiDbContext context) =>
        new(new DocumentTableRepository(context), new PatientRepository(context));
}
