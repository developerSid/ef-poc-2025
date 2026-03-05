namespace PayerEdi.Ingestion.Tokens;

/// <summary>
/// Provides EdiFabric token initialization and retrieval.
/// </summary>
public interface IEdiTokenProvider
{
    /// <summary>
    /// Initializes token state for downstream EDI processing.
    /// </summary>
    void InitToken();

    /// <summary>
    /// Gets a valid token value, generating or refreshing as needed.
    /// </summary>
    string GetToken();
}
