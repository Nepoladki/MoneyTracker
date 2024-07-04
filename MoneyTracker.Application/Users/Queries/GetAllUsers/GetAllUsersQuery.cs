using System.Data.Common;
using ErrorOr;
using MediatR;
using MoneyTracker.Domain.Entities;

public record GetAllUsersQuery : IRequest<ErrorOr<ICollection<User>>>;