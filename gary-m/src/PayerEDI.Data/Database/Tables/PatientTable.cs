using PayerEDI.Data.Models;

namespace PayerEDI.Data.Database.Tables;

public record PatientTable
{
    public Guid Id { get; init; } = Guid.CreateVersion7();
    public required string EntityType { get; init; }
    public string? EntityIdentifierCode { get; init; }
    public string? IdentificationCodeQualifier { get; init; }
    public string? ResponseContactIdentifier { get; init; }
    public string? LastName { get; init; }
    public string? SecondLastName { get; init; }
    public string? FirstName { get; init; }
    public string? MiddleName { get; init; }
    public string? Prefix { get; init; }
    public string? Suffix { get; init; }
    public string? OrganizationName { get; init; }
    public string? AdditionalOrganizationName { get; init; }
    public string? Relationship { get; init; }
}

public static class PatientTableExtensions
{
    extension(PatientTable)
    {
        public static PatientTable New(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
