using System.IO;

namespace PayerEdi.Ingestion;

public interface IEdiReaderFactory
{
    IEdiReader Create(Stream stream);
    ReaderSettings? CreateSettings(Stream stream, EdiStandard standard);
    BaseReader CreateReader(Stream stream, EdiStandard standard, ReaderSettings? readerSettings);
}
