using Microsoft.EntityFrameworkCore;

namespace PayerEDI.Data.Database;

public class PayerEdiDbContext(DbContextOptions<PayerEdiDbContext> options) : DbContext(options);
