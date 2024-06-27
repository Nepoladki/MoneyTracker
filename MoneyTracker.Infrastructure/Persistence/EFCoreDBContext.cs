using MoneyTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MoneyTracker.Infrastructure.Persistence;

public class EFCoreDBContext : DbContext
{
    public EFCoreDBContext(DbContextOptions<EFCoreDBContext> options) : base(options) {}

    public DbSet<User> Users { get; set; }
}