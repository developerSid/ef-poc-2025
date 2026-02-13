using PayerEdi.Ingestion.Sniffing;

namespace PayerEdi.Ingestion.Reader;

public sealed class EdiReaderFactory(IEdiReaderSniffer sniffer) : IEdiReaderFactory
{
    public IEdiReader Create(Stream stream)
    {
        ArgumentNullException.ThrowIfNull(stream);
        var standard = sniffer.DetectStandard(stream, out var readableStream);

        var settings = CreateSettings(readableStream, standard);
        var reader = CreateReader(readableStream, standard, settings);
        return new EdiReader(readableStream, reader);
    }

    public ReaderSettings? CreateSettings(Stream stream, EdiStandard standard) =>
        standard switch
        {
            EdiStandard.X12 => new X12ReaderSettings(),
            _ => throw new NotSupportedException("Unable to determine reader settings for the provided EDI standard.")
        };

    public BaseReader CreateReader(Stream stream, EdiStandard standard, ReaderSettings? readerSettings) =>
        standard switch
        {
            EdiStandard.X12 => new X12Reader(stream, typeof(EdiFabric.Templates.Hipaa5010.TS837P).Assembly.FullName, readerSettings as X12ReaderSettings),
            _ => throw new NotSupportedException("Unable to determine EDI standard for the provided stream.")
        };
}