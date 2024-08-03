namespace MoneyTracker.Contracts.Categories;
public record AddCategoryRequest(
    string CategoryName,
    bool IsPublic,
    Guid? CreatedByUserId);
