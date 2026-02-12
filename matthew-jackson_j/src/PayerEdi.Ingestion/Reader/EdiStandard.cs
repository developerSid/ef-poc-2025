namespace PayerEdi.Ingestion;

public enum EdiStandard
{
    Unknown = 0,
    X12,
    Edifact,
    Hl7,
    NcpdpTelecom,
    NcpdpScript
}
