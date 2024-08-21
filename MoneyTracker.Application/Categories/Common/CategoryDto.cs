using MoneyTracker.Domain.Enums;

namespace MoneyTracker.Application.Categories.Common;
public record CategoryDto(
    Guid CategoryId,
    bool IsPublic,
    string CategoryType,
    Guid? CreatedByUserId,
    string CategoryName);
