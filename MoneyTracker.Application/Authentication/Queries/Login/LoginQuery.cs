using ErrorOr;
using FoodDelivery.Application.Authentication.Common;
using MediatR;

namespace FoodDelivery.Application.Authentication.Queries.Login;

public record LoginQuery(
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>; 