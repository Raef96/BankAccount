using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.App.Interfaces.Services;

public interface ITransactionService
{
    bool AddTransaction(Transaction transaction);
    List<Transaction> GetTransactionsByCardId(Guid cardId);
}
