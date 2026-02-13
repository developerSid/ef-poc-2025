using System.IO;

namespace PayerEdi.Ingestion.Reader;

public interface IEdiReaderFactory
{
    /// <summary>
    /// Creates an EDI reader for the supplied stream based on detected standard.
    /// </summary>
    IEdiReader Create(Stream stream);

    /// <summary>
    /// Creates reader settings for a known EDI standard.
    /// </summary>
    ReaderSettings? CreateSettings(Stream stream, EdiStandard standard);

    /// <summary>
    /// Creates a concrete reader instance using the detected standard and settings.
    /// </summary>
    BaseReader CreateReader(Stream stream, EdiStandard standard, ReaderSettings? readerSettings);
}