using Bank.Domain.Entities;
using Bank.App.Interfaces.Repositories.Base;

namespace Bank.App.Interfaces.Repositories;

public interface IAccountRepository : IRepository<Account>
{
    List<Guid> GetAllIds();
    bool Withdrawel(Guid accountId, decimal amount);
    bool Deposit(Guid accountId, decimal amount);
    decimal GetBalance(Guid accountId);
}
