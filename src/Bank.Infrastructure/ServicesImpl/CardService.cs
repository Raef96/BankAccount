using Bank.Domain.Dtos;
using Bank.Domain.Entities;
using Bank.App.Interfaces.Services;
using Bank.App.Interfaces.Repositories;

namespace Bank.Infrastructure.ServicesImpl;

internal class CardService : ICardService
{
    private readonly ICardRepository _cardRepository;
    public CardService(ICardRepository cardRepository)
    {
        _cardRepository = cardRepository;
    }

    public Card GetCardByNumber(string cardNumber)
    {
        return _cardRepository.GetCardByNumber(cardNumber);
    }
}
