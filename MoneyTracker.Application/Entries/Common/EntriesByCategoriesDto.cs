namespace MoneyTracker.Application.Entries.Common;
public record EntriesByCategoriesOuterDto
{
    public Guid CategoryId { get; init; }
    public string CategoryName { get; init; } = null!;
    public List<EntriesByCategoriesInnerDto> Entries { get; init; } = null!;
}

public record EntriesByCategoriesInnerDto
{
    public Guid Id { get; init; }
    public decimal Amount { get; init; }
    public string CurrencyAbbr { get; init; } = null!;
    public string Note { get; init; } = null!;
    public DateTime DateTime { get; init; }
}