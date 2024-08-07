using MoneyTracker.Domain.Entities;

namespace MoneyTracker.Application.Common.Interfaces.Persistence;
public interface ICategoryUserIconRepository
{
    Task<bool> CategoryIconExistsAsync(Guid categoryId, Guid userId);
    Task<CategoryUserIcon?> GetCategoryUserIconAsync(Guid categoryId, Guid userId);
    Task<bool> SaveAsync();
}