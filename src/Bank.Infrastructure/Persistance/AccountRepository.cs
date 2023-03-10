using Bank.Domain.Enums;
using Bank.Domain.Entities;
using Bank.Domain.Exceptions;
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
        if (amount < 0)
        {
            throw new NegativeAmountException(amount);
        }

        using (var transaction = _dbContext.Database.BeginTransaction())
        {
            try
            {
                var account = Get(accountId);
                if (account is null)
                {
                    return false;
                }

                // create a pending bank transaction 
                var bankTransaction = new Transaction
                {
                    AccountId = accountId,
                    CreationDate = DateTime.UtcNow,
                    Amount = amount,
                    Type = TransactionType.Debit,
                    Status = TransactionStatus.Pending
                };

                if (account.Balance < amount)
                {
                    // create a failed transaction
                    bankTransaction.Status = TransactionStatus.Rejected;
                    _transactionRepository.Add(bankTransaction);
                    transaction.Commit();

                    return false;
                }

                account.Balance -= amount;
                _dbContext.Update(account);
                _dbContext.SaveChanges();

                bankTransaction.Status = TransactionStatus.Accepted;
                _transactionRepository.Add(bankTransaction);

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
        if (amount < 0)
        {
            throw new NegativeAmountException(amount);
        }

        using (var transaction = _dbContext.Database.BeginTransaction())
        {
            try
            {
                var account = Get(accountId);
                if (account is null)
                {
                    // log account is not found
                    return false;
                }

                // create a pending bank transaction 
                var bankTransaction = new Transaction
                {
                    AccountId = accountId,
                    CreationDate = DateTime.UtcNow,
                    Amount = amount,
                    Type = TransactionType.Credit,
                    Status = TransactionStatus.Pending
                };

                account.Balance += amount;
                _dbContext.Update(account);
                _dbContext.SaveChanges();

                bankTransaction.Status = TransactionStatus.Accepted;
                _transactionRepository.Add(bankTransaction);

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

    public List<Guid> GetAllIds()
    {
        return _dbContext.Accounts.Select(a => a.Id)
            .ToList();
    }

    public override bool Add(Account account)
    {
        if (account == null)
        {
            return false;
        }

        if (account.Balance < 0)
        {
            throw new NegativeBalanceException(account.Balance);
        }

        return base.Add(account);
    }
}
