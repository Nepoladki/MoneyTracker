namespace MoneyTracker.Api.Common.Options;

public class DBConnectionOptions
{
    public const string Name = "PostgresConnection";
    public string PostgresConnection { get; set; } = null!;
}