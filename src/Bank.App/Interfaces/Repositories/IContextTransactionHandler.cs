namespace Bank.App.Interfaces.Repositories;

public interface IContextTransactionHandler
{
    bool BeginTransaction();
    void CommitTransaction();
    void RollbackTransaction();
}
