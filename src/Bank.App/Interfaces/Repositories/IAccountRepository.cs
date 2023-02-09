using Bank.Domain.Entities;

namespace Bank.App.Interfaces.Repositories;

public interface IAccountRepository
{
    void UpdateAccountBalance(Account? account, decimal amount);
    Account? GetAccountById(Guid accountId);
}
