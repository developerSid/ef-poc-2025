using Microsoft.EntityFrameworkCore;
using PayerEDI.Data.Database.Tables;

namespace PayerEDI.Data.Database;

public class PayerEdiDbContext(DbContextOptions<PayerEdiDbContext> options) : DbContext(options)
{
    public DbSet<DocumentTable> Documents => Set<DocumentTable>();
    public DbSet<PatientTable> Patients => Set<PatientTable>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var document = modelBuilder.Entity<DocumentTable>();

        document.ToTable("documents");
        document.HasKey(item => item.Id);
        document.Property(item => item.Id).HasColumnType("uniqueidentifier").ValueGeneratedNever();
        document.Property(item => item.EdiMessageType).HasMaxLength(128).IsRequired();
        document.Property(item => item.Xml).HasColumnType("xml").IsRequired();

        var patient = modelBuilder.Entity<PatientTable>();

        patient.ToTable("Patients");
        patient.HasKey(item => item.Id);
        patient.Property(item => item.Id).HasColumnType("uniqueidentifier").ValueGeneratedNever();

        patient.Property(item => item.EntityType).HasMaxLength(10).IsRequired();
        patient.Property(item => item.EntityIdentifierCode).HasMaxLength(3);
        patient.Property(item => item.IdentificationCodeQualifier).HasMaxLength(2);
        patient.Property(item => item.ResponseContactIdentifier).HasMaxLength(80);
        patient.Property(item => item.LastName).HasMaxLength(60);
        patient.Property(item => item.SecondLastName).HasMaxLength(60);
        patient.Property(item => item.FirstName).HasMaxLength(35);
        patient.Property(item => item.MiddleName).HasMaxLength(25);
        patient.Property(item => item.Prefix).HasMaxLength(10);
        patient.Property(item => item.Suffix).HasMaxLength(10);
        patient.Property(item => item.OrganizationName).HasMaxLength(60);
        patient.Property(item => item.AdditionalOrganizationName).HasMaxLength(60);
        patient.Property(item => item.Relationship).HasMaxLength(2);
    }
}
