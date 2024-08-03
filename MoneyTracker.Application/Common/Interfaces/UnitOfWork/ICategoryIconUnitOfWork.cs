using Microsoft.AspNetCore.Http;
using MoneyTracker.Domain.Entities;

namespace MoneyTracker.Application.Common.Interfaces.UnitOfWork;
public interface ICategoryIconUnitOfWork
{
    Task<bool> AddCategoryIconAsync(IFormFile file);
    string GetCategoryIcon(Guid categoryId, Guid userId);
}
