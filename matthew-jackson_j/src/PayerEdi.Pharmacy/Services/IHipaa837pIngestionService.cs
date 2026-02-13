using EdiFabric.Core.Model.Edi;

namespace PayerEdi.Pharmacy.Services;

public interface IHipaa837pIngestionService
{
    /// <summary>
    /// Parses EDI payload items from the provided stream and persists supported entities.
    /// </summary>
    Task<List<IEdiItem>> IngestAsync(Stream stream, CancellationToken cancellationToken = default);
}