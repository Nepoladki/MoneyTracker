namespace MoneyTracker.Contracts.Entries;

public record AddEntryRequest(
    decimal Amount,
    Guid CategoryId,
    string Note,
    Guid UserId);