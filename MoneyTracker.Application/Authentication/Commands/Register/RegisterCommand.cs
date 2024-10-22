using ErrorOr;
using MoneyTracker.Application.Authentication.Common;
using MediatR;

namespace MoneyTracker.Application.Authentication.Commands.Register;

public record RegisterCommand(
    string UserName,
    string FirstName,
    string LastName,
    string Email,
    string Password,
    string PasswordCopy) : IRequest<ErrorOr<AuthenticationResult>>; 