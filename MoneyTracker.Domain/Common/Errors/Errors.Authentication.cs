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
        
        public static Error SavingError => Error.Unexpected(
            code: "Auth.DatabaseSavingError",
            description: "Error occured while saving new user in database");

        public static Error InactiveUser => Error.Forbidden(
            code: "Auth.InactiveUser",
            description: "Cannot log in, user's account deactivated");

        public static Error RefreshNotFound => Error.Unauthorized(
            code: "Auth.RefreshTokenNotFound",
            description: "Refresh token was not found in cookies");

        public static Error InvalidRefresh => Error.Unauthorized(
            code: "Auth.InvalidRefreshToken",
            description: "Security system can't validate refresh token");

        public static Error InvalidAccess => Error.Unauthorized(
            code: "Auth.InvalidAccessToken",
            description: "Security system can't validate access token");

        public static Error DifferentIds => Error.Unauthorized(
            code: "Auth.DifferentIds",
            description: "User's IDs in access and refresh tokens are different");

        public static Error InvalidAuthHeader => Error.Unauthorized(
            code: "Auth.InvalidAuthHeader",
            description: "Error occured while parsing Authorization header");

        public static Error AccessClaimWasNotFound => Error.Unauthorized(
            code: "Auth.AccessIdClaimNotFound",
            description: "Identifing claim was not found in access token");

        public static Error RefreshClaimWasNotFound => Error.Unauthorized(
            code: "Auth.RefreshIdClaimNotFound",
            description: "Identifing claim was not found in refresh token");

        public static Error HttpContextIsNull => Error.Unexpected(
            code: "Auth.HttpContextIsNull",
            description: "HttpContext is Null, refresh token is unreachable");

    }
}