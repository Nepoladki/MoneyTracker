namespace MoneyTracker.Domain.Entities;

public class Entry
{
    public Entry(
        decimal amount,
        Guid categoryId,
        Guid userId,
        string note,
        DateTime dateTime)
    {
        Amount = amount;
        CategoryId = categoryId;
        UserId = userId;
        Note = note;
        DateTime = dateTime;
    }
    public Guid Id { get; set; }
    public decimal Amount { get; set; }
    public string CurrencyAbbr { get; set; } = "RUB";
    public Guid CategoryId { get; set; }
    public string Note { get; set; } = string.Empty;
    public DateTime DateTime { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
    public Category Category { get; set; } = null!;
}