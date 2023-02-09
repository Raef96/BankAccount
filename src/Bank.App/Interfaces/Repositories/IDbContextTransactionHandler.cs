namespace Bank.App.Interfaces.Repositories;

internal interface IDbContextTransactionHandler<TDbContext>
{
    bool BeginTransaction();
    void CommitTransaction();
    void RollbackTransaction();
}
