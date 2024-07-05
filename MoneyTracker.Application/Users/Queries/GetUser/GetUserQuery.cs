using ErrorOr;
using MediatR;
using MoneyTracker.Domain.Entities;

namespace MoneyTracker.Application.Users.Queries.GetUser;

public record GetUserQuery(Guid Id) : IRequest<ErrorOr<User>>;