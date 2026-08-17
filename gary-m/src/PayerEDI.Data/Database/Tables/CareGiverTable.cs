namespace PayerEDI.Data.Database.Tables;

public record CareGiverTable
{
    public Guid Id { get; init; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public required string LastName { get; set; }
    public required string Title { get; set; }
}
