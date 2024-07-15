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
            description: "Error occured while saving updated user in repository");

        public static Error PasswordUpdatingError => Error.Unexpected(
            code: "User.SavingUpdatedPasswordError",
            description: "Error Occured while saving new password in repository");
    }
}