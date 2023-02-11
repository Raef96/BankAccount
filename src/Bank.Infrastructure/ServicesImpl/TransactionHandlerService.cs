using Bank.App.Interfaces.Services;
using Bank.App.Interfaces.Repositories;

namespace Bank.Infrastructure.ServicesImpl;

internal class TransactionHandlerService : ITransactionHandlerService
{
    private readonly IContextTransactionHandler _transactionHandler;
    public TransactionHandlerService(IContextTransactionHandler transactionHandler)
    {
        _transactionHandler = transactionHandler;
    }

    public bool StartTransaction(Func<Guid, decimal, bool> func, Guid arg1, decimal arg2)
    {
        var isCreated = _transactionHandler.BeginTransaction();
        if (!isCreated)
        {
            return false;
        }

        bool success;
        try
        {
            success = func.Invoke(arg1, arg2);
        }
        catch (Exception ex)
        {
            // TODO: log exception
            success = false;
        }

        if (success)
        {
            _transactionHandler.CommitTransaction();
        }
        else
        {
            _transactionHandler.RollbackTransaction();
        }

        return success;
    }
}
