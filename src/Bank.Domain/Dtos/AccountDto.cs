using Bank.Domain.Entities;

namespace Bank.Domain.Dtos;

public class AccountDto
{
    public string Owner { get; set; }
    public string IBAN { get; set; }
    public string RIB { get; set; }
    public decimal Balance { get; set; }

    public AccountDto()
    {
    }

    public AccountDto(Account account)
    {
        Owner = account.Owner;
        IBAN = account.IBAN;
        RIB = account.RIB;
        Balance = account.Balance;
    }
}
