using MoneyTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MoneyTracker.Infrastructure.Persistence;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) {}
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Entry> Entries { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<CategoryIcon> CategoriesIcons { get; set; } = null!;

}