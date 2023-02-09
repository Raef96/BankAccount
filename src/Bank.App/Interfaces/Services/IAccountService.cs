using Bank.Domain.Entities;

namespace Bank.App.Interfaces.Services;

public interface IAccountService
{
    void UpdateAccountBalance(Account? account, decimal amount);
    Account? GetAccountById(Guid accountId);
}
