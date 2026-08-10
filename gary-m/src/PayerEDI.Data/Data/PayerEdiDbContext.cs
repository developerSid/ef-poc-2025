using Microsoft.EntityFrameworkCore;

namespace PayerEDI.Data.Data;

public class PayerEdiDbContext(DbContextOptions<PayerEdiDbContext> options) : DbContext(options);
