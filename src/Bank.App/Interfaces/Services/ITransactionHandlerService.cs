namespace Bank.App.Interfaces.Services;

public interface ITransactionHandlerService
{
    bool StartTransaction(Func<Guid, decimal, bool> func, Guid arg1, decimal arg2);
}
