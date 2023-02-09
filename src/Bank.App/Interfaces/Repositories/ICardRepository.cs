using Bank.Domain.Entities;

namespace Bank.App.Interfaces.Repositories;

public interface ICardRepository
{
    Card? GetCardByNumber(string cardNumber);

    Card? GetCardById(Guid id);
}
