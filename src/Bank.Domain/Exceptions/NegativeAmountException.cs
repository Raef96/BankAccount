namespace Bank.Domain.Exceptions;

internal class NegativeAmountException : Exception
{
    public NegativeAmountException()
    {

    }

    public NegativeAmountException(decimal amount) :
        base($"Invalid amount {amount}")
    {

    }
}
