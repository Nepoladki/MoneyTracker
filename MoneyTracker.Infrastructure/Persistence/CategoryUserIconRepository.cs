using Microsoft.EntityFrameworkCore;
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

    public async Task<bool> CategoryIconExistsAsync(Guid categoryId, Guid userId)
    {
        return await _context.CategoriesUsersIcons.AnyAsync(x => x.UserId == userId && x.CategoryId == categoryId);
    }

    public async Task<CategoryUserIcon?> GetCategoryUserIconAsync(Guid categoryId, Guid userId)
    {
        return await _context.CategoriesUsersIcons.
            FirstOrDefaultAsync(x => x.CategoryId == categoryId && x.UserId == userId);
    }

    public async Task<bool> SaveAsync() => await _context.SaveChangesAsync() > 0;
    
}
