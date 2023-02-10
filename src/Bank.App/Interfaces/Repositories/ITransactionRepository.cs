using Bank.App.Interfaces.Repositories.Base;
using Bank.Domain.Entities;

namespace Bank.App.Interfaces.Repositories;

public interface ITransactionRepository : IRepository<Transaction>
{
    bool AddTransaction(Transaction transaction);
    List<Transaction> GetTransactionsByCardId(Guid cardId);
}
