namespace PayerEdi.Ingestion.Reader;

/// <summary>
/// Wraps an EdiFabric reader instance and the underlying stream with a simple <see cref="IEdiReader"/> API.
/// </summary>
public sealed class EdiReader(Stream stream, BaseReader reader) : IEdiReader
{
    /// <summary>
    /// Reads the next parsed EDI item, or <see langword="null"/> when the stream is exhausted.
    /// </summary>
    public IEdiItem? Read() => 
        reader.Read() ? reader.Item : null;

    /// <summary>
    /// Disposes the EdiFabric reader and its owning stream.
    /// </summary>
    public void Dispose()
    {
        reader.Dispose();
        stream.Dispose();
    }
}
