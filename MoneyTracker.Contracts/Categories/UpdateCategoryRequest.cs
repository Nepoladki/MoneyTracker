using Microsoft.AspNetCore.Http;

namespace MoneyTracker.Contracts.Categories;
public record UpdateCategoryRequest(
        string CategoryName,
        bool IsPublic,
        Guid CreatedByUserId,
        IFormFile? Icon);
