namespace PayerEDI.Data.Database.Tables;

public record DocumentTable
{
    public Guid Id { get; init; } = Guid.CreateVersion7();
    public required string EdiMessageType { get; init; }
    public required string Xml { get; init; }
}
