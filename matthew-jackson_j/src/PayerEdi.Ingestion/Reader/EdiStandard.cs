namespace PayerEdi.Ingestion.Reader;

/// <summary>
/// Supported EDI standards recognized by stream sniffing.
/// </summary>
public enum EdiStandard
{
    /// <summary>No known EDI standard was detected.</summary>
    Unknown = 0,
    /// <summary>ANSI X12.</summary>
    X12,
    /// <summary>UN/EDIFACT.</summary>
    Edifact,
    /// <summary>HL7 message formats.</summary>
    Hl7,
    /// <summary>NCPDP Telecom transactions.</summary>
    NcpdpTelecom,
    /// <summary>NCPDP SCRIPT transactions.</summary>
    NcpdpScript
}
