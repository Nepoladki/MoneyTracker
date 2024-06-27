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
            description: "UserName is already in use"
        );
    }
}