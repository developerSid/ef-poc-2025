namespace PayerEdi.Ingestion.S3;

/// <summary>
/// Connection settings for <see cref="S3Consumer"/>.
/// </summary>
public sealed class S3ConsumerOptions
{
    /// <summary>S3-compatible service endpoint URL.</summary>
    public string EndpointUrl { get; set; } = "http://127.0.0.1:5000";
    /// <summary>AWS region used by the client.</summary>
    public string Region { get; set; } = "us-east-1";
    /// <summary>Access key credential.</summary>
    public string AccessKey { get; set; } = "test";
    /// <summary>Secret key credential.</summary>
    public string SecretKey { get; set; } = "test";
    /// <summary>When true, bucket name is encoded in the request path.</summary>
    public bool ForcePathStyle { get; set; } = true;
}
