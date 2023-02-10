using Bank.Domain.Entities;

namespace Bank.App.Interfaces.Services;

public interface ICardService
{
    Card GetCardByNumber(string cardNumber);
}
