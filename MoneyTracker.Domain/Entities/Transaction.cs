namespace MoneyTracker.Domain.Entities;

public class Transaction
{
    public Guid Id { get; set; }
    public Decimal Amount { get; set; }
    public string CurrencyAbbr { get; set; } = "RUB";
    public Guid CategoryId { get; set; }
    public string Note { get; set; } = string.Empty;
    public DateTime DateTime { get; set; }
    public Guid UserId { get; set; }
}