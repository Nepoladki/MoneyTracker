using ErrorOr;
using MediatR;

namespace MoneyTracker.Application.Users.Commands.DeleteUser;

public record DeleteUserCommand(Guid Id) : IRequest<ErrorOr<Guid>>;