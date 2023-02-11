using Bank.Domain.Entities;
using Bank.App.Interfaces.Services;
using Bank.App.Interfaces.Repositories;

namespace Bank.Infrastructure.ServicesImpl;

internal class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;
    private readonly ITransactionHandlerService _transactionHandlerService;

    public AccountService(
        IAccountRepository accountRepository,
        ITransactionHandlerService transactionHandlerService)
    {
        _accountRepository = accountRepository;
        _transactionHandlerService = transactionHandlerService;
    }

    public decimal GetBalance(Guid accountId)
    {
        
        return _accountRepository.GetBalance(accountId);
    }

    public bool Deposit(Guid accountId, decimal amount)
    {
        //create a new transaction
        var account = _accountRepository.Get(accountId);

        return _transactionHandlerService.StartTransaction(_accountRepository.Deposit, accountId, amount);
    }

    public bool Withdrawel(Guid accountId, decimal amount)
    {
        return _transactionHandlerService.StartTransaction(_accountRepository.Withdrawel, accountId, amount);
    }
}
