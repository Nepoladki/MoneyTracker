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

        public static Error DifferentPasswords => Error.Validation(
            code: "User.DifferentPasswords",
            description: "Password and PasswordCopy are different");

        public static Error UserNotFound => Error.NotFound(
            code: "User.NotFound",
            description: "User was not found");
    }
}