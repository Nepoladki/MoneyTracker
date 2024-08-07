namespace MoneyTracker.Domain.Entities;
public class CategoryUserIcon
{
    public int Id { get; set; }
    public Guid CategoryId { get; set; }
    public Guid UserId { get; set; }
    public string FileName { get; set; } = null!;
    public User User { get; set; } = null!;
    public Category Category { get; set; } = null!;
}