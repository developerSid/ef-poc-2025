namespace PayerEdi.Ingestion.Tokens;

public interface IEdiTokenProvider
{
    void InitToken();
    string GetToken();
}