using ErrorOr;

namespace FoodDelivery.Domain.Common.Errors;

public static partial class Errors
{
    public static class Authentication
    {
        public static Error InvalidCredentials => Error.Validation(
            code: "Auth.InvalidCreds",
            description: "Invalid credentials");
    }
}