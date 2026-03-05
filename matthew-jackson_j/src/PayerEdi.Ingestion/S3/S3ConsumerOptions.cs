namespace PayerEdi.Ingestion.S3;

/// <summary>
/// Connection settings for <see cref="S3Consumer"/>.
/// </summary>
public sealed class S3ConsumerOptions
{
    /// <summary>S3-compatible service endpoint URL.</summary>
    public string EndpointUrl { get; set; } = string.Empty;
    /// <summary>AWS region used by the client.</summary>
    public string Region { get; set; } = string.Empty;
    /// <summary>Access key credential.</summary>
    public string AccessKey { get; set; } = string.Empty;
    /// <summary>Secret key credential.</summary>
    public string SecretKey { get; set; } = string.Empty;
    /// <summary>When true, bucket name is encoded in the request path.</summary>
    public bool ForcePathStyle { get; set; }
}
