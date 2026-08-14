using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PayerEDI.Data.Database;

namespace PayerEDI.Test.FT.Database.Fixtures;

public sealed class SqlServerFixture
{
    private readonly string connectionString =
        Environment.GetEnvironmentVariable("PAYEREDI_TEST_CONNECTION_STRING")
        ?? "Server=localhost,1434;Database=PayerEdi;User Id=payeredi_app;Password=payeredi_app_password;TrustServerCertificate=True";
    private readonly string adminConnectionString =
        Environment.GetEnvironmentVariable("PAYEREDI_TEST_ADMIN_CONNECTION_STRING")
        ?? "Server=localhost,1434;Database=PayerEdi;User Id=sa;Password=password_123;TrustServerCertificate=True";
    private readonly SemaphoreSlim preparationLock = new(1, 1);

    public PayerEdiDbContext CreateContext()
    {
        var options = new DbContextOptionsBuilder<PayerEdiDbContext>()
            .UseSqlServer(connectionString)
            .Options;

        return new PayerEdiDbContext(options);
    }

    public PayerEdiDbContext CreateAdminContext()
    {
        var options = new DbContextOptionsBuilder<PayerEdiDbContext>()
            .UseSqlServer(adminConnectionString)
            .Options;

        return new PayerEdiDbContext(options);
    }

    public async Task PrepareDatabaseAsync()
    {
        await preparationLock.WaitAsync();
        try
        {
            await using var context = CreateAdminContext();
            await context.Database.MigrateAsync();

            await using var connection = (SqlConnection)context.Database.GetDbConnection();
            await connection.OpenAsync();
            await SqlServerTestDatabaseCleaner.CleanAsync(connection);
        }
        finally
        {
            preparationLock.Release();
        }
    }
}
