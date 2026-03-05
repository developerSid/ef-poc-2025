using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace PayerEdi.Pharmacy.Data.Hipaa837p;

/// <summary>
/// Design-time DbContext factory for EF Core tooling and migration commands.
/// </summary>
public sealed class Hipaa837pDbContextFactory : IDesignTimeDbContextFactory<Hipaa837pDbContext>
{
    /// <inheritdoc />
    public Hipaa837pDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();
        var cs = configuration.GetConnectionString("HipaaDb")
            ?? throw new InvalidOperationException("Configuration key 'ConnectionStrings:HipaaDb' is required.");

        var options = new DbContextOptionsBuilder<Hipaa837pDbContext>()
            .UseSqlServer(cs)
            .Options;

        return new Hipaa837pDbContext(options);
    }

    private static IConfiguration BuildConfiguration()
    {
        var currentDirectory = new DirectoryInfo(Directory.GetCurrentDirectory());
        while (currentDirectory is not null)
        {
            var solutionPath = Path.Combine(currentDirectory.FullName, "PayerEdi.Pharmacy.slnx");
            if (File.Exists(solutionPath))
            {
                return new ConfigurationBuilder()
                    .SetBasePath(currentDirectory.FullName)
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                    .Build();
            }

            currentDirectory = currentDirectory.Parent;
        }

        return new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
            .Build();
    }
}
