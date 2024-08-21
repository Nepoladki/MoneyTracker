using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoneyTracker.Application.Common.Interfaces.Persistence;
using MoneyTracker.Domain.Entities;
using MoneyTracker.Domain.Enums;

namespace MoneyTracker.Infrastructure.Persistence;
public class CategoryRepository : ICategoryRepository
{
    private readonly DataContext _context;

    public CategoryRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<bool> AddCategoryAsync(Category category)
    {
        await _context.Categories.AddAsync(category);
        return await SaveAsync();
    }

    public async Task<bool> PrivateCategoryExistsAsync(string categoryName, Guid? userId, CategoryType categoryType)
    {
        return await _context.Categories.AnyAsync(
            c => c.CategoryName.ToLower() == categoryName.ToLower() 
            && c.IsPublic == false
            && c.CreatedByUserId == userId
            && c.CategoryType == categoryType);
    }

    public async Task<bool> PublicCategoryExistsAsync(string categoryName, CategoryType categoryType)
    {
        return await _context.Categories.AnyAsync(
            c => c.CategoryName.ToLower() == categoryName.ToLower()
            && c.IsPublic == true
            && c.CategoryType == categoryType);
    }

    public async Task<bool> CategoryExistByNameAsync(string name)
    {
        return await _context.Categories.AnyAsync(c => c.CategoryName.ToLower().Equals(name.ToLower()));
    }

    public async Task<bool> DeleteCategoryAsync(Category category)
    {
        _context.Remove(category);
        return await SaveAsync();
    }

    public async Task<ICollection<Category>> GetAllPublicCategoriesAsync()
    {
        return await _context.Categories.Where(c => c.IsPublic == true).ToListAsync();
    }

    public async Task<ICollection<Category>> GetAllCategoriesForUser(Guid userId)
    {
        return await _context.Categories.Where(c => c.CreatedByUserId == userId).ToListAsync();
    }

    public async Task<ICollection<Category>> GetAllCategoriesAsync()
    {
        return await _context.Categories.ToListAsync();
    }

    public async Task<Category?> GetCategoryByIdAsync(Guid id)
    {
        return await _context.Categories.Where(c => c.Id == id).FirstOrDefaultAsync();
    }

    public async Task<bool> SaveAsync() => await _context.SaveChangesAsync() > 0;
}
