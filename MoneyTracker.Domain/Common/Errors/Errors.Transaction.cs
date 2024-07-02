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
            code: "Transaction.InvalidCategoryId",
            description: "Error occured while creating new transaction: category id is invalid");

        public static Error InvalidUserId => Error.Validation(
            code: "Transaction.InvalidUserId",
            description: "Error occured while creating new transaction: user id is invalid");

        public static Error RepositoryError => Error.Unexpected(
            code: "Transaction.RepositoryError",
            description: "Error occured while calling repository method");


    }
}