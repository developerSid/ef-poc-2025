using EdiFabric.Core.Model.Edi;
using PayerEdi.Ingestion.IO;
using PayerEdi.Ingestion.Reader;
using PayerEdi.Ingestion.Tokens;
using PayerEdi.Pharmacy.Data.Hipaa837p;

namespace PayerEdi.Pharmacy.Services;

/// <summary>
/// Parses 837P content and persists EF-mapped parsed items in a single database transaction.
/// </summary>
public sealed class Hipaa837pIngestionService(
    IFileService fileService,
    IEdiReaderFactory readerFactory,
    IEdiTokenProvider tokenProvider,
    Hipaa837pDbContext dbContext) : IHipaa837pIngestionService
{
    /// <inheritdoc />
    public async Task<List<IEdiItem>> IngestAsync(string bucket, string key, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(bucket);
        ArgumentException.ThrowIfNullOrWhiteSpace(key);

        tokenProvider.InitToken();

        var payload = await fileService.PullAsync(bucket, key, cancellationToken);
        await using var stream = new MemoryStream(payload, writable: false);

        using var reader = readerFactory.Create(stream);
        var items = reader.ReadAll();

        using var scope = await dbContext.Database.BeginTransactionAsync(cancellationToken);

        foreach(var item in items)
        {
            // Skip parsed artifacts that are not modeled in the current DbContext.
            if (dbContext.Model.FindEntityType(item.GetType()) == null)
                continue;

            dbContext.Add(item);
        }

        await dbContext.SaveChangesAsync(cancellationToken);
        await scope.CommitAsync(cancellationToken);

        return items;
    }
}
