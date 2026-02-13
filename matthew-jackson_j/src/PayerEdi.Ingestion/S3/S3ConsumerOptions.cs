namespace PayerEdi.Ingestion.S3;

public sealed class S3ConsumerOptions
{
    public string EndpointUrl { get; set; } = "http://127.0.0.1:5000";
    public string Region { get; set; } = "us-east-1";
    public string AccessKey { get; set; } = "test";
    public string SecretKey { get; set; } = "test";
    public bool ForcePathStyle { get; set; } = true;
}