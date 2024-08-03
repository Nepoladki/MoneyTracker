using MoneyTracker.Domain.Entities;

namespace MoneyTracker.Application.Common.Interfaces.Persistence;
public interface ICategoryUserIconRepository
{
    Task<bool> AddCategoryIconAsync(CategoryUserIcon icon);
    Task<bool> CategoryIconExistsAsync(Guid categoryId, Guid userId);
    string GetCategoryIcon(Guid categoryId, Guid userId);
    bool Save();
}