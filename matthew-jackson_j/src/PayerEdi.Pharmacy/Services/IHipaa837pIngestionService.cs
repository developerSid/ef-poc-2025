using EdiFabric.Core.Model.Edi;

namespace PayerEdi.Pharmacy.Services;

public interface IHipaa837pIngestionService
{
    /// <summary>
    /// Parses EDI payload items from the configured file service and persists supported entities.
    /// </summary>
    Task<List<IEdiItem>> IngestAsync(string bucket, string key, CancellationToken cancellationToken = default);
}
