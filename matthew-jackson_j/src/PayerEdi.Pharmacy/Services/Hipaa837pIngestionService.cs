using EdiFabric.Core.Model.Edi;
using PayerEdi.Ingestion;
using PayerEdi.Ingestion.Reader;
using PayerEdi.Pharmacy.Data.Hipaa837p;

namespace PayerEdi.Pharmacy.Services;

public sealed class Hipaa837pIngestionService : IHipaa837pIngestionService
{
    private readonly IEdiReaderFactory _readerFactory;
    private readonly IEdiTokenProvider _tokenProvider;
    private readonly Hipaa837pDbContext _dbContext;

    public Hipaa837pIngestionService(
        IEdiReaderFactory readerFactory,
        IEdiTokenProvider tokenProvider,
        Hipaa837pDbContext dbContext)
    {
        _readerFactory = readerFactory ?? throw new ArgumentNullException(nameof(readerFactory));
        _tokenProvider = tokenProvider ?? throw new ArgumentNullException(nameof(tokenProvider));
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<List<IEdiItem>> IngestAsync(Stream stream, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(stream, nameof(stream));

        _tokenProvider.InitToken();

        using var reader = _readerFactory.Create(stream);
        var items = reader.ReadAll();

        using var scope = await _dbContext.Database.BeginTransactionAsync();

        foreach(var item in items)
        {
            if (_dbContext.Model.FindEntityType(item.GetType()) == null)
                //throw new NotSupportedException($"Unable to save models of type {item.GetType().FullName} to the {_dbContext.GetType().FullName} database context.");
                continue;

            _dbContext.Add(item);
        }

        await _dbContext.SaveChangesAsync();
        await scope.CommitAsync();

        return items;
    }
}
