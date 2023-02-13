using Bank.Domain.Dtos;
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
        try
        {
            return _accountRepository.Deposit(accountId, amount);
        }
        catch
        {
            // log 
        }

        return false;
    }

    public bool Withdrawel(Guid accountId, decimal amount)
    {
        try
        {
            return _accountRepository.Withdrawel(accountId, amount);
        }
        catch
        {
            // log
        }

        return false;   
    }

    public AccountDto GetById(Guid id)
    {
        var account = _accountRepository.Get(id);
        return new AccountDto(account);
    }

    public bool Add(AccountDto account)
    {
        try
        {
            return _accountRepository.Add(new Account
            {
                Id = Guid.NewGuid(),
                Balance = account.Balance,
                IBAN = account.IBAN,
                Owner = account.Owner,
                RIB = account.RIB
            });
        }
        catch
        {

        }
        
        return false;
    }

    public IEnumerable<AccountDto> GetAll()
    {
        return _accountRepository.GetAll()
                    .Select(acc => new AccountDto(acc));
    }

    public IEnumerable<Guid> GetAllIds()
    {
        return _accountRepository.GetAllIds();
    }
}
