using Microsoft.EntityFrameworkCore;
using MoneyTracker.Application.Common.Interfaces.Persistence;
using MoneyTracker.Domain.Entities;

namespace MoneyTracker.Infrastructure.Persistence;
public class CategoryRepository : ICategoryRepository
{
    private readonly DataContext _context;

    public CategoryRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<bool> DeleteCategoryAsync(Category category)
    {
        _context.Remove(category);
        return await SaveAsync();
    }

    public async Task<ICollection<Category>?> GetAllCategoriesAsync()
    {
        return await _context.Categories.ToListAsync();
    }

    public async Task<Category?> GetCategoryByIdAsync(Guid id)
    {
        return await _context.Categories.Where(c => c.Id == id).FirstOrDefaultAsync();
    }

    public async Task<bool> SaveAsync() => await _context.SaveChangesAsync() > 0;
}
