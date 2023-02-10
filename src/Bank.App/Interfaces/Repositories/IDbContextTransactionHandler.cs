namespace Bank.App.Interfaces.Repositories;

public interface IDbContextTransactionHandler<TDbContext>
{
    bool BeginTransaction();
    void CommitTransaction();
    void RollbackTransaction();
}
