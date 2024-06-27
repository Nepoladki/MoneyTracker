using ErrorOr;

namespace MoneyTracker.Domain.Common.Errors;

public static partial class Errors
{
    public static class Authentication
    {
        public static Error InvalidCredentials => Error.Validation(
            code: "Auth.InvalidCreds",
            description: "Invalid credentials");

        public static Error HashingError => Error.Unexpected(
            code: "Auth.HashingError",
            description: "Exeption occured while trying to hash password");

        public static Error VeryfingPasswordHashError => Error.Unexpected(
            code: "Auth.VerifyPasswordHashError",
            description: "Exeption occured while trying to verify user's password");
    }
}