using Bank.Domain.Entities;
using Bank.App.Interfaces.Services;
using Bank.App.Interfaces.Repositories;

namespace Bank.Infrastructure.ServicesImpl;

internal class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;

    public AccountService(
        IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public decimal GetBalance(Guid accountId)
    {

        return _accountRepository.GetBalance(accountId);
    }

    public bool Deposit(Guid accountId, decimal amount)
    {
        return _accountRepository.Deposit(accountId, amount);
    }

    public bool Withdrawel(Guid accountId, decimal amount)
    {
        return _accountRepository.Withdrawel(accountId, amount);
    }
}
