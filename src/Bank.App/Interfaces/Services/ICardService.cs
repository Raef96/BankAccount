using Bank.Domain.Entities;
using Bank.Domain.Dtos;
using Bank.App.Interfaces.Services.Base;

namespace Bank.App.Interfaces.Services;

public interface ICardService : IService<CardDto>
{
    Card GetCardByNumber(string cardNumber);
}
