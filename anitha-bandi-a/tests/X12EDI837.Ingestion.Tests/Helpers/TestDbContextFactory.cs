using Microsoft.EntityFrameworkCore;
using X12EDI837.Ingestion.Infrastructure;

namespace X12EDI837.Ingestion.Tests.Helpers;

/// <summary>
/// Creates a fresh in-memory AppDbContext for each test — no real SQL Server needed.
/// </summary>
public static class TestDbContextFactory
{
    public static AppDbContext Create(string? dbName = null)
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(dbName ?? Guid.NewGuid().ToString()) // unique DB per test
            .Options;

        var ctx = new AppDbContext(options);
        ctx.Database.EnsureCreated();
        return ctx;
    }
}
