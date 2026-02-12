namespace PayerEdi.Ingestion;

public sealed class EdiReaderFactory : IEdiReaderFactory
{
    private readonly IEdiReaderSniffer _sniffer;

    public EdiReaderFactory(IEdiReaderSniffer sniffer)
    {
        _sniffer = sniffer ?? throw new ArgumentNullException(nameof(sniffer));
    }

    public IEdiReader Create(Stream stream)
    {
        var readerStream = stream ?? throw new ArgumentNullException(nameof(stream));
        var standard = _sniffer.DetectStandard(stream, out var readableStream);
        readerStream = readableStream;

        var settings = CreateSettings(readerStream, standard);
        var reader = CreateReader(readerStream, standard, settings);
        return new EdiReader(readerStream, reader);
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
