using Bank.Domain.Entities.Base;

namespace Bank.Domain.Entities;

public class Account : Entity
{
    public string Owner { get; set; }
    public string IBAN { get; set; }
    public string RIB { get; set; }
    public decimal Balance { get; set; }
}
