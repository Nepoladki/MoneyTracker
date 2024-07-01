namespace MoneyTracker.Domain.Entities;

public class Transaction
{
    public Guid Id { get; set; }
    public Decimal Amount { get; set; }
    public string CurrencyAbbr { get; set; }
    public string FixedExchangeRate { get; set; }
    public string CountryAbbr { get; set; }
    public Guid CategoryId { get; set; }
    public Guid PlaceId { get; set; }
    public Guid Tags { get; set; } //Спросить у Егора как будут храниться теги
    public string Note { get; set; }
    public DateTime DateTime { get; set; }
    public Guid UserId { get; set; }
    public Guid ProfileId { get; set; }
}