namespace MoneyTracker.Domain.Entities;

public class Category
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string CategoryName { get; set; } = string.Empty;
    public string IconPath { get; set; } = string.Empty;
    public ICollection<Entry> Entry { get; set; } = null!;
}