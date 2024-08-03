using MoneyTracker.Application.Common.Interfaces.Persistence;
using MoneyTracker.Domain.Entities;

namespace MoneyTracker.Infrastructure.Persistence;
public class CategoryUserIconRepository : ICategoryUserIconRepository
{
    private readonly DataContext _context;

    public CategoryUserIconRepository(DataContext context)
    {
        _context = context;
    }

    public Task<bool> AddCategoryIconAsync(CategoryUserIcon icon)
    {
        _context.CategoriesUsersIcons.
    }

    public Task<bool> CategoryIconExistsAsync(Guid categoryId, Guid userId)
    {
        throw new NotImplementedException();
    }

    public string GetCategoryIcon(Guid categoryId, Guid userId)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> SaveAsync() => await _context.SaveChangesAsync() > 0;
    
}
