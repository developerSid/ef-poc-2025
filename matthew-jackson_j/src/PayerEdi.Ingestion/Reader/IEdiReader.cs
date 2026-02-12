namespace PayerEdi.Ingestion;

public interface IEdiReader : IDisposable
{
    IEdiItem? Read();
}
