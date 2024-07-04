using ErrorOr;
using MediatR;

namespace MoneyTracker.Application.Users.Commands;

public record DeleteUserCommand(Guid Id) : IRequest<ErrorOr<Guid>>;