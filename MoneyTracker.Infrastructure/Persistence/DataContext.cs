using MoneyTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MoneyTracker.Infrastructure.Persistence;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) {}
    public DbSet<User> Users { get; set; } = null!;
}