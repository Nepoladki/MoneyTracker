namespace MoneyTracker.Application.Entries.Common;

public record EntryDto(
    Guid id,
    decimal amount,
    string currencyAbbr,
    Guid categoryId,
    string note,
    DateTime dateTime,
    Guid userId
);