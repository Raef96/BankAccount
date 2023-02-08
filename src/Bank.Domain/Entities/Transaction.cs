using Bank.Domain.Enums;
using Bank.Domain.Entities.Base;

namespace Bank.Domain.Entities;

public class Transaction : Entity
{
    public Guid CardId { get; set; }
    public decimal Amount { get; set; }
    public string Currency { get; set; }
    public DateTime CreationDate { get; set; }
    public TransactionType Type { get; set; }
    public TransactionStatus Status { get; set; }
}
