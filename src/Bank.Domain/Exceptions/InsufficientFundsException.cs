
namespace Bank.Domain.Exceptions;

public class InsufficientFundsException : Exception
{
    public InsufficientFundsException()
    {

    }
    public InsufficientFundsException(decimal amountTowithdraw) :
        base(
        $"withdrawn amount {amountTowithdraw} should be between 0 and the current balance"
        )
    {

    }
}
