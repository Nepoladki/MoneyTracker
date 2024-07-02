using ErrorOr;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;

namespace MoneyTracker.Domain.Common.Errors;

public static partial class Errors
{
    public static class Transactions
    {
        public static Error InvalidAmount => Error.Validation(
            code: "Transaction.InvalidAmount",
            description: "Amount of money in transaction cannot be zero or negative");
        
        public static Error InvalidCategoryId => Error.Validation(
            code: "TransactionInvalidCategoryId",
            description: "Error occured while creating new transaction: category id is invalid");
    }
}