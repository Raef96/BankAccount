using Bank.Domain.Entities;
using Bank.App.Interfaces.Repositories;
using Bank.Infrastructure.Persistance.Base;

namespace Bank.Infrastructure.Persistance;

internal class CardRepository : Repository<Card>, ICardRepository
{
    public CardRepository(BankDbContext bankDbContext) : base(bankDbContext)
    {

    }

    public Card GetCardByNumber(string cardNumber)
    {
        return _dbContext.Cards.Where(card => card.CardNumber == cardNumber)
            .FirstOrDefault();
    }
}
