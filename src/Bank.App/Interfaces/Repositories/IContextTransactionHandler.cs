namespace Bank.App.Interfaces.Repositories;

public interface IContextTransactionHandler<TContext>
{
    bool BeginTransaction();
    void CommitTransaction();
    void RollbackTransaction();
}
