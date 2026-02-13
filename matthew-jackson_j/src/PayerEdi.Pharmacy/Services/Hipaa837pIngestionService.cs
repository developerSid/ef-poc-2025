using EdiFabric.Core.Model.Edi;
using PayerEdi.Ingestion.Reader;
using PayerEdi.Ingestion.Tokens;
using PayerEdi.Pharmacy.Data.Hipaa837p;

namespace PayerEdi.Pharmacy.Services;

public sealed class Hipaa837pIngestionService(
    IEdiReaderFactory readerFactory,
    IEdiTokenProvider tokenProvider,
    Hipaa837pDbContext dbContext) : IHipaa837pIngestionService
{
    /// <inheritdoc />
    public async Task<List<IEdiItem>> IngestAsync(Stream stream, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(stream, nameof(stream));

        tokenProvider.InitToken();

        using var reader = readerFactory.Create(stream);
        var items = reader.ReadAll();

        using var scope = await dbContext.Database.BeginTransactionAsync(cancellationToken);

        foreach(var item in items)
        {
            if (dbContext.Model.FindEntityType(item.GetType()) == null)
                continue;

            dbContext.Add(item);
        }

        await dbContext.SaveChangesAsync(cancellationToken);
        await scope.CommitAsync(cancellationToken);

        return items;
    }
}