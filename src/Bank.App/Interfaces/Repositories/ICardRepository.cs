using Bank.Domain.Entities;
using Bank.App.Interfaces.Repositories.Base;

namespace Bank.App.Interfaces.Repositories;

public interface ICardRepository : IRepository<Card>
{
    Card GetCardByNumber(string cardNumber);
}
