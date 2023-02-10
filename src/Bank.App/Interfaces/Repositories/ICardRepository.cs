using Bank.App.Interfaces.Repositories.Base;
using Bank.Domain.Entities;

namespace Bank.App.Interfaces.Repositories;

public interface ICardRepository: IRepository<Card>
{
    Card? GetCardByNumber(string cardNumber);
    Card? GetCardById(Guid id);
}
