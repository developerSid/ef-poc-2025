namespace PayerEDI.Data.Db.Tables;

public record Patient
{
    public Guid Id { get; init; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
