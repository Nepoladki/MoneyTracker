namespace MoneyTracker.Application.Transactions.Common;

public record TransactionDto(
    Guid id,
    decimal amount,
    string currencyAbbr,
    Guid categoryId,
    string note,
    DateTime dateTime,
    Guid userId
);