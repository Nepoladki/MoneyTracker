namespace MoneyTracker.Contracts.Entries;

public record UpdateEntryRequest(
    Guid Id,
    decimal Amount,
    string CurrencyAbbr,
    DateTime DateTime,
    Guid CategoryId,
    string Note,
    Guid UserId);