namespace Bank.Domain.Exceptions;

internal class NegativeBalanceException : Exception
{
    public NegativeBalanceException()
    {

    }

    public NegativeBalanceException(decimal balance) :
        base($"can not create an account with negative balance {balance}")
    {

    }
}
