using MoneyTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MoneyTracker.Infrastructure.Persistence;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) {}
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Entry> Entries { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<CategoryUserIcon> CategoriesUsersIcons { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>()
            .HasOne(c => c.User)
            .WithMany(u => u.Categories)
            .HasForeignKey(c => c.CreatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Category>()
            .HasIndex(c => new { c.CategoryName, c.IsPublic })
            .IsUnique()
            .HasFilter("is_public = TRUE");

        modelBuilder.Entity<Category>()
            .HasIndex(c => new { c.CategoryName, c.CreatedByUserId })
            .IsUnique()
            .HasFilter("is_public = FALSE");
    }
}