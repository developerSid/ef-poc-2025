namespace PayerEdi.Ingestion.Tokens;

/// <summary>
/// Configures EdiFabric token initialization.
/// </summary>
public sealed class EdiFabricOptions
{
    /// <summary>
    /// Configuration section name.
    /// </summary>
    public const string SectionName = "EdiFabric";

    /// <summary>
    /// EdiFabric serial key.
    /// </summary>
    public string SerialKey { get; set; } = string.Empty;
}
