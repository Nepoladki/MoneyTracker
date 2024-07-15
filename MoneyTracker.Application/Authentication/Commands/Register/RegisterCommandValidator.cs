using FluentValidation;

namespace MoneyTracker.Application.Authentication.Commands.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.Email).EmailAddress();
        RuleFor(x => x.UserName).MinimumLength(6).MaximumLength(35).Matches(@"^\S+$");
        RuleFor(x => x.Password).NotEmpty().MinimumLength(6).MaximumLength(35).Equal(x => x.PasswordCopy);
    }
}