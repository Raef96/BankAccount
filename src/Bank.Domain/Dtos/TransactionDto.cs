using Bank.Domain.Enums;
using Bank.Domain.Entities;

namespace Bank.Domain.Dtos;

public class TransactionDto
{
    public TransactionType TransactionType { get; set; }

    public string OperationType => TransactionType.ToString();

    public string Currency { get; set; }

    public decimal Amount { get; set; }

    public DateTime CreationDate { get; set; }

    public TransactionStatus Status { get; set; }

    public TransactionDto()
    {
    }
    public TransactionDto(Transaction transaction)
    {
        TransactionType = transaction.Type;
        Currency = transaction.Currency;
        Amount = transaction.Amount;
        Status = transaction.Status;
        CreationDate = transaction.CreationDate;
    }
}
