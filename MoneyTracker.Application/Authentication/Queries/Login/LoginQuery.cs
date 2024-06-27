using ErrorOr;
using MoneyTracker.Application.Authentication.Common;
using MediatR;

namespace MoneyTracker.Application.Authentication.Queries.Login;

public record LoginQuery(
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>; 