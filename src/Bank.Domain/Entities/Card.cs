using Bank.Domain.Enums;
using Bank.Domain.Entities.Base;

namespace Bank.Domain.Entities;

public class Card : Entity
{
    public Guid AccountId { get; set; }
    public string Owner { get; set; }
    public string CardNumber { get; set; }
    public CardStatus CardStatus { get; set; }
    public DateTime ExpirationDate { get; set; }
    public byte[] Salt { get; set; }
    public byte[] SecretCode { get; set; }

    public CardStatus GetCardStatus() =>
        ExpirationDate < DateTime.UtcNow ? CardStatus.Expired : CardStatus;
}
