using Bank.Domain.Entities;

namespace Bank.App.Interfaces.Repositories;

public interface ITransactionRepository
{
    bool AddTransaction(Transaction transaction);
    List<Transaction> GetTransactionsByCardId(Guid cardId);
}
