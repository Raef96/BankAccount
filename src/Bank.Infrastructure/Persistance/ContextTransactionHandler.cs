using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Bank.App.Interfaces.Repositories;

namespace Bank.Infrastructure.Persistance;

internal class ContextTransactionHandler : IContextTransactionHandler
{
    private readonly DbContext _dbContext;
    private IDbContextTransaction? _transaction;

    public ContextTransactionHandler(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public bool BeginTransaction()
    {
        // a transaction is already created
        if (_transaction != null)
        {
            return false;
        }

        _transaction = _dbContext.Database.BeginTransaction();
        return true;
    }

    public void CommitTransaction()
    {
        if (_transaction is null) return;
        using (_transaction)
        {
            _dbContext.Database.CommitTransaction();
        }
    }
    public void RollbackTransaction()
    {
        if (_transaction is null) return;

        using (_transaction)
        {
            _dbContext.Database.RollbackTransaction();
        }
    }
}
