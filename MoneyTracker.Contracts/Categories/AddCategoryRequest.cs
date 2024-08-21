namespace MoneyTracker.Contracts.Categories;
public record AddCategoryRequest(
    string CategoryName,
    string CategoryType,
    bool IsPublic,
    Guid? CreatedByUserId);
