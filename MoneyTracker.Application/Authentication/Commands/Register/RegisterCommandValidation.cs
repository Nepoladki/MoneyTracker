using FluentValidation;

namespace MoneyTracker.Application.Authentication.Commands.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.Email).EmailAddress();
        RuleFor(x => x.Password).NotEmpty().NotNull().MinimumLength(6).MaximumLength(35);
    }
}