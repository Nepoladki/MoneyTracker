using ErrorOr;
using FoodDelivery.Application.Authentication.Common;
using MediatR;

namespace FoodDelivery.Application.Authentication.Commands.Register;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>; 