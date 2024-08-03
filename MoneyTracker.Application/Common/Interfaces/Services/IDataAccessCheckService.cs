namespace MoneyTracker.Application.Common.Interfaces.Services;
public interface IDataAccessCheckService
{
    public bool CheckUserAccessToData(Guid? requestUserId);
}
