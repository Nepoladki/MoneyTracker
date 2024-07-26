namespace MoneyTracker.Application.Common.Interfaces.Persistence;
public interface ICategoryIconRepository
{
    bool CategoryIconExists(Guid categoryId, Guid userId);
    string GetCategoryIcon(Guid categoryId, Guid userId);
}