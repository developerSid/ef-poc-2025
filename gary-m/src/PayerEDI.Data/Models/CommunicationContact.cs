namespace PayerEDI.Data.Models;

public record CommunicationNumber(string Number, CommunicationNumberQualifier Qualifier);

public record CommunicationsContact(
    string ContactFunctionCode,
    string? Name,
    CommunicationNumber? PrimaryNumber,
    CommunicationNumber? SecondaryNumber,
    CommunicationNumber? TertiaryNumber
);
