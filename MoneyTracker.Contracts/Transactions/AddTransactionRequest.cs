namespace MoneyTracker.Contracts.Transactions;

public record AddTransactionRequest(
    decimal Amount,
    Guid CategoryId,
    string Note,
    Guid UserId);