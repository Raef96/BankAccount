namespace Bank.App.Interfaces.Services;

public interface IAccountService
{
    bool Withdrawel(Guid accountId, decimal amount);
    bool Deposit(Guid accountId, decimal amount);
    decimal GetBalance(Guid accountId);
}
