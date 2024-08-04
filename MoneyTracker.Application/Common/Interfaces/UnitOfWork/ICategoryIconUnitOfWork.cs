using ErrorOr;
using Microsoft.AspNetCore.Http;
using MoneyTracker.Application.CategoriesIcons.Commands;
using MoneyTracker.Domain.Entities;

namespace MoneyTracker.Application.Common.Interfaces.UnitOfWork;
public interface ICategoryIconUnitOfWork
{
    Task<ErrorOr<bool>> SetCategoryIconAsync(SetCategoryIconCommand request);
    string GetCategoryIcon();
}