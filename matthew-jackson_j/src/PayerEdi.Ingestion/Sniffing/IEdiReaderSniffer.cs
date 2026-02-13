using System.IO;
using PayerEdi.Ingestion.Reader;

namespace PayerEdi.Ingestion.Sniffing;

public interface IEdiReaderSniffer
{
    /// <summary>
    /// Detects the likely EDI standard from the stream prefix.
    /// </summary>
    EdiStandard DetectStandard(Stream stream);

    /// <summary>
    /// Detects the EDI standard and provides a readable stream for downstream parsing.
    /// </summary>
    EdiStandard DetectStandard(Stream stream, out Stream readableStream);
}