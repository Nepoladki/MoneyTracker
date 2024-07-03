namespace MoneyTracker.Domain.Entities;

public class Category
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string CategoryName { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
    public ICollection<Transaction> Transaction { get; set; } = null!;
}