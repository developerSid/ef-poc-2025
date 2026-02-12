using EdiFabric.Core.Model.Edi;

namespace PayerEdi.Pharmacy.Services;

public interface IHipaa837pIngestionService
{
    Task<List<IEdiItem>> IngestAsync(Stream stream, CancellationToken cancellationToken = default);
}
