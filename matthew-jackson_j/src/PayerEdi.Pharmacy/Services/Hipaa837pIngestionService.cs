using EdiFabric.Core.Model.Edi;
using Microsoft.Extensions.Logging;
using PayerEdi.Ingestion.IO;
using PayerEdi.Ingestion.Reader;
using PayerEdi.Ingestion.Tokens;
using PayerEdi.Pharmacy.Data.Hipaa837p;
using System.Linq;

namespace PayerEdi.Pharmacy.Services;

/// <summary>
/// Parses 837P content and persists EF-mapped parsed items in a single database transaction.
/// </summary>
public sealed class Hipaa837pIngestionService(
    ILogger<Hipaa837pIngestionService> logger,
    IFileService fileService,
    IEdiReaderFactory readerFactory,
    IEdiTokenProvider tokenProvider,
    IEnumerable<IIngestionPreSaveHook> preSaveHooks,
    Hipaa837pDbContext dbContext) : IHipaa837pIngestionService
{
    /// <inheritdoc />
    public async Task<List<IEdiItem>> IngestAsync(string bucket, string key, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(bucket);
        ArgumentException.ThrowIfNullOrWhiteSpace(key);

        logger.LogInformation("Starting ingestion for bucket '{Bucket}' key '{Key}'.", bucket, key);
        tokenProvider.InitToken();

        var payload = await fileService.PullAsync(bucket, key, cancellationToken);
        await using var stream = new MemoryStream(payload, writable: false);

        using var reader = readerFactory.Create(stream);
        var items = reader.ReadAll();
        logger.LogInformation("Parsed {Count} EDI item(s) from bucket '{Bucket}' key '{Key}'.", items.Count, bucket, key);

        var hooks = preSaveHooks as IIngestionPreSaveHook[] ?? [.. preSaveHooks];
        foreach (var hook in hooks)
            await hook.OnBeforeSaveAsync(items, cancellationToken);

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
        logger.LogInformation("Persisted ingestion results for bucket '{Bucket}' key '{Key}'.", bucket, key);

        return items;
    }
}
