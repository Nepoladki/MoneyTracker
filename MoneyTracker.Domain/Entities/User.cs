namespace MoneyTracker.Domain.Entities;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public bool IsActive { get; set; } = true;
    public string UserName { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public bool IsAdmin { get; set; } = false;
    public ICollection<Category> Categories { get; set; } = null!;
    public ICollection<Entry> Entries { get; set; } = null!;
}