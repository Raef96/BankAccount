using Bank.Domain.Entities;
using Bank.App.Interfaces.Repositories;
using Bank.Infrastructure.Persistance.Base;
using Bank.Domain.Enums;

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
        using (var transaction = _dbContext.Database.BeginTransaction())
        {
            try
            {

                var account = _dbContext.Accounts.Where(acc => acc.Id == accountId).FirstOrDefault();
                if (account is null || account.Balance < amount)
                {
                    // log account is not found or balance < amount
                    return false;
                }

                account.Balance -= amount;
                _dbContext.Update(account);
                _dbContext.SaveChanges();

                // create a new transaction
                var newTransaction = new Transaction
                {
                    AccountId = accountId,
                    CreationDate = DateTime.UtcNow,
                    Amount = amount,
                    Type = TransactionType.Debit,
                    Status = TransactionStatus.Accepted
                };

                _dbContext.Add(newTransaction);
                _dbContext.SaveChanges();

                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                // log exception
                transaction.Rollback();
            }
        };

        return false;
    }

    public bool Deposit(Guid accountId, decimal amount)
    {
        throw new NotImplementedException();
    }
}
