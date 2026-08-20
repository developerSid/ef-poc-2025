using EdiFabric.Templates.Hipaa5010;
using PayerEDI.Data.Helpers;

namespace PayerEDI.Data.Database.Tables;

public record DocumentTable
{
    public Guid Id { get; init; } = Guid.CreateVersion7();
    public required string EdiMessageType { get; init; }
    public required string Xml { get; init; }
}

public static class DocumentTableExtensions
{
    public static DocumentTable CreateDocument(this TS837P ts837P) =>
        new() { EdiMessageType = nameof(TS837P), Xml = ts837P.ToXml() };

    public static DocumentTable CreateDocument(this TS837D ts837D) =>
        new() { EdiMessageType = nameof(TS837D), Xml = ts837D.ToXml() };
}
