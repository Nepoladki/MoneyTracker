using System.Security.Cryptography.X509Certificates;

namespace MoneyTracker.Contracts.Transactions;

public record CreateTransactionRequest(
    Decimal Amount,
    Guid CategoryId,
    string Note,
    DateTime DateTime,
    Guid UserId);