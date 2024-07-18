using ErrorOr;

namespace MoneyTracker.Domain.Common.Errors;

public static partial class Errors
{
    public static class User
    {
        public static Error DuplicateEmail => Error.Conflict(
            code: "User.DuplicateEmail",
            description: "Email is already in use");
        
        public static Error DuplicateUserName => Error.Conflict(
            code: "User.DuplicateUserName",
            description: "UserName is already in use");

        public static Error UserNotFound => Error.NotFound(
            code: "User.NotFound",
            description: "User was not found");

        public static Error UpdatingError => Error.Unexpected(
            code: "User.SavingUpdatedUserError",
            description: "Error occured while saving updated user in database");

        public static Error PasswordUpdatingError => Error.Unexpected(
            code: "User.SavingUpdatedPasswordError",
            description: "Error occured while saving new password in database");

        public static Error NoUpdates => Error.Validation(
            code: "User.NoUpdates",
            description: "Updated user and existing one are equals, nothing to update");

        public static Error SamePassword => Error.Validation(
            code: "User.SamePassword",
            description: "New password equals existing one");

        public static Error UserIsInactive => Error.Forbidden(
            code: "User.InactiveUser",
            description: "User's account is marked as inactive");
    }
}