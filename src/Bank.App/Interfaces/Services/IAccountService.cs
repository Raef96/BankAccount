using Bank.Domain.Dtos;
using Bank.App.Interfaces.Services.Base;

namespace Bank.App.Interfaces.Services;

public interface IAccountService : IService<AccountDto>
{
    bool Withdrawel(Guid accountId, decimal amount);
    bool Deposit(Guid accountId, decimal amount);
    decimal GetAccountBalance(Guid accountId);
}
