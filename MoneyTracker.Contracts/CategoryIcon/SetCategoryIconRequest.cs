using Microsoft.AspNetCore.Http;

namespace MoneyTracker.Contracts.CategoryIcon;
public class SetCategoryIconRequest
{
    public Guid CategoryId { get; set; }
    public Guid UserId { get; set; }
    public IFormFile File { get; set; } = null!;
}
