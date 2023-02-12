using Bank.Domain.Dtos;

namespace Bank.App.Interfaces.Services;

public interface IAccountService
{
    bool Add(AccountDto account);
    AccountDto GetById(Guid id);
    IEnumerable<Guid> GetAllIds();
    IEnumerable<AccountDto> GetAll();
    bool Withdrawel(Guid accountId, decimal amount);
    bool Deposit(Guid accountId, decimal amount);
    decimal GetBalance(Guid accountId);
}
