namespace MoneyTracker.Application.Entries.Common;

public record EntryDto(
    Guid Id,
    decimal Amount,
    string CurrencyAbbr,
    Guid CategoryId,
    string Note,
    DateTime DateTime,
    Guid UserId
);