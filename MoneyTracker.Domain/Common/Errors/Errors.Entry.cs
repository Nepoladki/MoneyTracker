using ErrorOr;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;

namespace MoneyTracker.Domain.Common.Errors;

public static partial class Errors
{
    public static class Entries
    {
        public static Error InvalidAmount => Error.Validation(
            code: "Entry.InvalidAmount",
            description: "Amount of money in entry cannot be zero or negative");
        
        public static Error InvalidCategoryId => Error.Validation(
            code: "Entry.InvalidCategoryId",
            description: "Error occured while creating new entry: category id is invalid");

        public static Error InvalidUserId => Error.Validation(
            code: "Entry.InvalidUserId",
            description: "Error occured while creating new entry: user id is invalid");

        public static Error RepositoryError => Error.Unexpected(
            code: "Entry.RepositoryError",
            description: "Error occured while calling repository method");

        public static Error EntryNotFound => Error.NotFound(
            code: "Entry.NotFound",
            description: "Entry was not found in database");

        public static Error NoUpdates => Error.Validation(
            code: "Entry.NoUpdates",
            description: "Updated entry equals existing one");


    }
}