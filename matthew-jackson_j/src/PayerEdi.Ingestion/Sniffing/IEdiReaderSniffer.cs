using System.IO;

namespace PayerEdi.Ingestion;

public interface IEdiReaderSniffer
{
    EdiStandard DetectStandard(Stream stream);
    EdiStandard DetectStandard(Stream stream, out Stream readableStream);
}
