namespace Bank.Domain.Exceptions;

public class NegativeAmountException : Exception
{
    public NegativeAmountException()
    {

    }

    public NegativeAmountException(decimal amount) :
        base($"Invalid amount {amount}")
    {

    }
}
