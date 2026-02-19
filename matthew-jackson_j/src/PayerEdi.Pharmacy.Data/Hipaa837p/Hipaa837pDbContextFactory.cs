using Microsoft.EntityFrameworkCore.Design;

namespace PayerEdi.Pharmacy.Data.Hipaa837p;

/// <summary>
/// Design-time DbContext factory for EF Core tooling and migration commands.
/// </summary>
public sealed class Hipaa837pDbContextFactory : IDesignTimeDbContextFactory<Hipaa837pDbContext>
{
    /// <inheritdoc />
    public Hipaa837pDbContext CreateDbContext(string[] args)
    {
        var cs = Environment.GetEnvironmentVariable("HIPAA_DB_CONNECTION", EnvironmentVariableTarget.Machine)
            ?? throw new InvalidOperationException(
                "HIPAA_DB_CONNECTION environment variable not set.");

        var options = new DbContextOptionsBuilder<Hipaa837pDbContext>()
            .UseSqlServer(cs)
            .Options;

        return new Hipaa837pDbContext(options);
    }
}
