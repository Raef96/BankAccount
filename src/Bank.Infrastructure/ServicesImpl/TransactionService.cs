using Bank.Domain.Dtos;
using Bank.App.Interfaces.Services;
using Bank.App.Interfaces.Repositories;

namespace Bank.Infrastructure.ServicesImpl;

internal class TransactionService : ITransactionService
{
    private readonly ITransactionRepository _transactionRepository;

    public TransactionService(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    public List<TransactionDto> GetAllTransactions()
    {
        return _transactionRepository.GetAll()
            .Select(trans => new TransactionDto(trans))
            .ToList();
    }

    public List<TransactionDto> GetByAccountId(Guid accountId)
    {
        return _transactionRepository.GetByAccountId(accountId)
            .Select(trans => new TransactionDto(trans))
            .ToList();
    }
}
