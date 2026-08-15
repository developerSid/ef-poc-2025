using Microsoft.EntityFrameworkCore;
using PayerEDI.Data.Database.Tables;
using PayerEDI.Test.FT.Database.Fixtures;

namespace PayerEDI.Test.FT.Database;

public sealed class PatientTests(SqlServerFixture fixture)
    : IClassFixture<SqlServerFixture>,
        IAsyncLifetime
{
    public Task InitializeAsync() => fixture.PrepareDatabaseAsync();

    public Task DisposeAsync() => Task.CompletedTask;

    [Fact]
    public async Task Patients_table_is_available()
    {
        await using var context = fixture.CreateContext();

        Assert.True(await context.Database.CanConnectAsync());
        Assert.Equal("Patients", context.Model.FindEntityType(typeof(Patient))!.GetTableName());
    }

    [Fact]
    public async Task Migration_history_is_preserved()
    {
        await using var context = fixture.CreateContext();

        var migrationCount = await context
            .Database.SqlQueryRaw<int>(
                "SELECT COUNT(*) AS [Value] FROM [dbo].[__EFMigrationsHistory]"
            )
            .SingleAsync();

        Assert.True(migrationCount > 0);
    }

    [Fact]
    public async Task Person_and_organization_rows_persist_with_nullable_flattened_fields()
    {
        var person = new Patient
        {
            EntityType = "Person",
            EntityIdentifierCode = "IL",
            IdentificationCodeQualifier = "MI",
            ResponseContactIdentifier = "MEMBER-001",
            LastName = "Doe",
            FirstName = "Jane",
            Relationship = "25",
        };
        var organization = new Patient
        {
            EntityType = "NonPerson",
            EntityIdentifierCode = "PR",
            IdentificationCodeQualifier = "PI",
            ResponseContactIdentifier = "PAYER-001",
            OrganizationName = "Example Health Plan",
        };

        await using (var context = fixture.CreateContext())
        {
            context.Patients.AddRange(person, organization);
            await context.SaveChangesAsync();
        }

        await using (var context = fixture.CreateContext())
        {
            var persistedPerson = await context.Patients.SingleAsync(item => item.Id == person.Id);
            var persistedOrganization = await context.Patients.SingleAsync(item =>
                item.Id == organization.Id
            );

            Assert.Equal("25", persistedPerson.Relationship);
            Assert.Equal("Jane", persistedPerson.FirstName);
            Assert.Null(persistedPerson.OrganizationName);
            Assert.Equal("Example Health Plan", persistedOrganization.OrganizationName);
            Assert.Null(persistedOrganization.LastName);
        }
    }
}
