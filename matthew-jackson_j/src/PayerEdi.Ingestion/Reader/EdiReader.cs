namespace PayerEdi.Ingestion;

public sealed class EdiReader : IEdiReader
{
    private readonly Stream _stream;
    private readonly BaseReader _reader;

    public EdiReader(Stream stream, BaseReader reader)
    {
        _stream = stream ?? throw new ArgumentNullException(nameof(stream));
        _reader = reader ?? throw new ArgumentNullException(nameof(reader));
    }

    public IEdiItem? Read() => 
        _reader.Read() ? _reader.Item : null;

    public void Dispose()
    {
        _reader.Dispose();
        _stream.Dispose();
    }
}
