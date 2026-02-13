namespace PayerEdi.Ingestion.Reader;

public sealed class EdiReader(Stream stream, BaseReader reader) : IEdiReader
{
    public IEdiItem? Read() => 
        reader.Read() ? reader.Item : null;

    public void Dispose()
    {
        reader.Dispose();
        stream.Dispose();
    }
}