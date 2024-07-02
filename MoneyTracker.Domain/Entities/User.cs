namespace MoneyTracker.Domain.Entities;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public bool IsActive { get; set; } = true;
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public ICollection<Transaction> Transactions { get; set; } = null!;
}