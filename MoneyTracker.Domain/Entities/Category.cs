using MoneyTracker.Domain.Enums;

namespace MoneyTracker.Domain.Entities;

public class Category
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public CategoryType CategoryType { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public bool IsPublic { get; set; } = false;
    public Guid? CreatedByUserId { get; set; } = Guid.Empty;
    public User User { get; set; } = null!;
    public ICollection<Entry> Entries { get; set; } = null!;
}