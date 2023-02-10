namespace Bank.App.Interfaces.Services;

public interface ITransactionHandlerService
{
    bool StartTransaction(Func<bool> func);
}
