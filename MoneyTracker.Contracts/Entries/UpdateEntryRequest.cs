namespace MoneyTracker.Contracts.Entries;

public record UpdateEntryRequest(
    Guid Id,
    decimal Amount,
    Guid CategoryId,
    string Note,
    Guid UserId);