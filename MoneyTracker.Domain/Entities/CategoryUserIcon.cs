namespace MoneyTracker.Domain.Entities;
public class CategoryUserIcon
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid CategoryId { get; set; }
    public Guid UserId { get; set; }
    public string? FilePath { get; set; }
    public User User { get; set; } = null!;
    public Category Category { get; set; } = null!;
}