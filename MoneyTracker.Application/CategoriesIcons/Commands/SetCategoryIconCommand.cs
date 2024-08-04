using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace MoneyTracker.Application.CategoriesIcons.Commands;
public record SetCategoryIconCommand(Guid CategoryId, Guid UserId, IFormFile Icon) : IRequest<ErrorOr<bool>>;
