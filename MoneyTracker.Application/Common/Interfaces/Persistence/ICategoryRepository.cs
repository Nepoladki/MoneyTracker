using MoneyTracker.Domain.Entities;

namespace MoneyTracker.Application.Common.Interfaces.Persistence;
public interface ICategoryRepository
{
    public Task<ICollection<Category>?> GetAllCategoriesAsync();
    public Task<Category?> GetCategoryByIdAsync(Guid id);
    public Task<bool> DeleteCategoryAsync(Category category);
    public Task<bool> SaveAsync();

}