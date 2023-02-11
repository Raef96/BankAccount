using Bank.Domain.Entities;
using Bank.App.Interfaces.Repositories;
using Bank.Infrastructure.Persistance.Base;

namespace Bank.Infrastructure.Persistance;

internal class TransactionRepository : Repository<Transaction>, ITransactionRepository
{
	public TransactionRepository(BankDbContext bankDbContext) : base(bankDbContext)
	{

	}

    public List<Transaction> GetByAccountId(Guid accountId)
    {
        throw new NotImplementedException();
    }
}
