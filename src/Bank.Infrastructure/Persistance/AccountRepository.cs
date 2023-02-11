using Bank.Domain.Entities;
using Bank.App.Interfaces.Repositories;
using Bank.Infrastructure.Persistance.Base;

namespace Bank.Infrastructure.Persistance;

internal class AccountRepository : Repository<Account>, IAccountRepository
{
    private readonly ITransactionRepository _transactionRepository;
    public AccountRepository(ITransactionRepository transactionRepository,
        BankDbContext dbContext) : base(dbContext)
    {
        _transactionRepository = transactionRepository;
    }

    public decimal GetBalance(Guid accountId)
    {
        return _dbContext.Accounts.Where(account => account.Id == accountId)
            .Select(account => account.Balance)
            .FirstOrDefault();
    }

    public bool Withdrawel(Guid accountId, decimal amount)
    {
        throw new NotImplementedException();
    }

    public bool Deposit(Guid accountId, decimal amount)
    {
        throw new NotImplementedException();
    }
}
