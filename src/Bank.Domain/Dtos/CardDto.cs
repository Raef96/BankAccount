using Bank.Domain.Enums;

namespace Bank.Domain.Dtos;

public class CardDto
{
    public Guid AccountId { get; set; }
    public string Owner { get; set; }
    public string CardNumber { get; set; }
    public CardStatus CardStatus { get; set; }
    public DateTime ExpirationDate { get; set; }
}
