namespace PayerEdi.Ingestion;

public interface IEdiTokenProvider
{
    void InitToken();
    string GetToken();
}
