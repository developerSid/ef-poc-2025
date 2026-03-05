namespace PayerEdi.Ingestion.Reader;

public interface IEdiReader : IDisposable
{
    /// <summary>
    /// Reads the next EDI item from the underlying stream.
    /// </summary>
    IEdiItem? Read();
}