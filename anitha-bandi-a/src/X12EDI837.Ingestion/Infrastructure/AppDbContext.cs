using Microsoft.EntityFrameworkCore;
using X12EDI837.Ingestion.Domain;

namespace X12EDI837.Ingestion.Infrastructure;

/// <summary>
/// EF Core DbContext for all 837P ingestion domain entities.
/// </summary>
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // Keeps generated migration files under Infrastructure/Migrations/
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured) return;
        optionsBuilder.UseSqlServer(o => o.MigrationsHistoryTable("__EFMigrationsHistory"));
    }

    public DbSet<Claim>               Claims               => Set<Claim>();
    public DbSet<BillingProvider>     BillingProviders     => Set<BillingProvider>();
    public DbSet<Subscriber>          Subscribers          => Set<Subscriber>();
    public DbSet<ServiceLine>         ServiceLines         => Set<ServiceLine>();
    public DbSet<DiagnosisCode>       DiagnosisCodes       => Set<DiagnosisCode>();
    public DbSet<SnipValidationError> SnipValidationErrors => Set<SnipValidationError>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // ── Claim ────────────────────────────────────────────────────────────
        modelBuilder.Entity<Claim>(e =>
        {
            e.HasKey(c => c.Id);
            e.Property(c => c.ClaimId).HasMaxLength(50).IsRequired();
            e.Property(c => c.TotalChargeAmount).HasColumnType("decimal(18,2)");
            e.HasIndex(c => c.ClaimId).IsUnique();   // prevent duplicate claim IDs
        });

        // ── BillingProvider (1-to-1 with Claim) ─────────────────────────────
        modelBuilder.Entity<BillingProvider>(e =>
        {
            e.HasKey(b => b.Id);
            e.HasOne(b => b.Claim)
             .WithOne(c => c.BillingProvider)
             .HasForeignKey<BillingProvider>(b => b.ClaimId)
             .OnDelete(DeleteBehavior.Cascade);
        });

        // ── Subscriber (1-to-1 with Claim) ──────────────────────────────────
        modelBuilder.Entity<Subscriber>(e =>
        {
            e.HasKey(s => s.Id);
            e.HasOne(s => s.Claim)
             .WithOne(c => c.Subscriber)
             .HasForeignKey<Subscriber>(s => s.ClaimId)
             .OnDelete(DeleteBehavior.Cascade);
        });

        // ── ServiceLine (many-to-1 with Claim) ──────────────────────────────
        modelBuilder.Entity<ServiceLine>(e =>
        {
            e.HasKey(s => s.Id);
            e.Property(s => s.LineChargeAmount).HasColumnType("decimal(18,2)");
            e.Property(s => s.Quantity).HasColumnType("decimal(18,3)");
            e.HasOne(s => s.Claim)
             .WithMany(c => c.ServiceLines)
             .HasForeignKey(s => s.ClaimId)
             .OnDelete(DeleteBehavior.Cascade);
        });

        // ── DiagnosisCode (many-to-1 with Claim) ────────────────────────────
        modelBuilder.Entity<DiagnosisCode>(e =>
        {
            e.HasKey(d => d.Id);
            e.HasOne(d => d.Claim)
             .WithMany(c => c.DiagnosisCodes)
             .HasForeignKey(d => d.ClaimId)
             .OnDelete(DeleteBehavior.Cascade);
        });

        // ── SnipValidationError (many-to-1 with Claim) ──────────────────────
        modelBuilder.Entity<SnipValidationError>(e =>
        {
            e.HasKey(s => s.Id);
            e.HasOne(s => s.Claim)
             .WithMany(c => c.SnipValidationErrors)
             .HasForeignKey(s => s.ClaimId)
             .OnDelete(DeleteBehavior.Cascade);
        });
    }
}
