using Bank.Domain.Dtos;
namespace Bank.App.Interfaces.Services;

public interface ITransactionService
{
    List<TransactionDto> GetAllTransactions();
}
