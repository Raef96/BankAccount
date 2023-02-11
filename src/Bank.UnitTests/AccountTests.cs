using Bank.Domain.Entities;
using Bank.App.Interfaces.Repositories;
using Bank.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;

namespace Bank.UnitTests;

public class AccountTests
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly IAccountRepository _accountRepository;
    private readonly BankDbContext _context;

    public AccountTests()
    {
        var connection = new SqliteConnection("DataSource=:memory:");
        connection.Open();

        var optionsBuilder = new DbContextOptionsBuilder<BankDbContext>()
            .UseSqlite(connection);
            //.UseInMemoryDatabase(Guid.NewGuid().ToString());

        _context = new BankDbContext(optionsBuilder.Options);
        _context.Database.EnsureCreated();

        _transactionRepository = new TransactionRepository(_context);
        _accountRepository = new AccountRepository(_transactionRepository, _context);
    }

    [Fact]
    public void Add_NewAccount_ShoulBeAddedSuccessfully()
    {
        var success = _accountRepository.Add(new Account
        {
            Id = Guid.NewGuid(),
            Owner = "Jhon",
            IBAN = "FR65122554666",
            RIB = "30048665451464",
            Balance = 100,
        });

        Assert.True(success);
    }

    [Fact]
    public void Withdraw_FromAccount_WithPositiveBalance_IsCorrect()
    {
        // create an account
        var accountId = Guid.NewGuid();
        _context.Add(new Account
        {
            Id = accountId,
            Balance = 100
        });
        _context.SaveChanges();

        var success = _accountRepository.Withdrawel(accountId, 50);

        var modifiedAccount = _context.Accounts.Where(acc => acc.Id == accountId).FirstOrDefault();

        Assert.NotNull(modifiedAccount);
        Assert.True(success);
        Assert.Equal(50, modifiedAccount.Balance);
    }

    [Fact]
    public void Withdraw_FromAccount_WithPositiveBalance_IsInCorrect()
    {
        // create an account
        var accountId = Guid.NewGuid();
        _context.Add(new Account
        {
            Id = accountId,
            Balance = 100
        });
        _context.SaveChanges();

        var success = _accountRepository.Withdrawel(accountId, 200);
        Assert.False(success);
    }

    [Fact]
    public void Withdraw_FromAccount_WithNoBalance_ShouldReturnException()
    {
        var accountId = Guid.NewGuid();
        _context.Add(new Account
        {
            Id = accountId,
            Balance = 0
        });
        _context.SaveChanges();


        var success = _accountRepository.Withdrawel(accountId, 10);
        Assert.False(success);

    }

    [Fact]
    public void Withdraw_FromAccount_ShouldCreateNewTransaction()
    {
        var accountId = Guid.NewGuid();
        _context.Add(new Account
        {
            Id = accountId,
            Balance = 100
        });
        _context.SaveChanges();

        var trasactionsCntBeoreWithdraw = _context.Transactions.Count();

        var success = _accountRepository.Withdrawel(accountId, 10);
        Assert.True(success);

        
        var trasactionsCntAfterWithdraw = _context.Transactions.Count();

        Assert.Equal(trasactionsCntBeoreWithdraw + 1, trasactionsCntAfterWithdraw);
    }

    [Fact]
    public void Deposit_InAccount_ShouldCreateNewTransaction()
    {
        var accountId = Guid.NewGuid();
        _context.Add(new Account
        {
            Id = accountId,
            Balance = 100
        });
        _context.SaveChanges();

        var trasactionsCntBeoreWithdraw = _context.Transactions.Count();

        var success = _accountRepository.Deposit(accountId, 10);
        Assert.True(success);


        var trasactionsCntAfterWithdraw = _context.Transactions.Count();

        Assert.Equal(trasactionsCntBeoreWithdraw + 1, trasactionsCntAfterWithdraw);
    }

    [Fact]
    public void Deposit_InAccount_IsCorrect()
    {
        var accountId = Guid.NewGuid();
        _context.Add(new Account
        {
            Id = accountId,
            Balance = 100
        });
        _context.SaveChanges();

        var success = _accountRepository.Deposit(accountId, 200);
        Assert.True(success);

        var account = _context.Accounts.Where(acc => acc.Id == accountId).FirstOrDefault();
        Assert.NotNull(account);

        Assert.Equal(300, account.Balance);
    }

    [Fact]
    public void Deposit_Exception_BalanceShouldNotBeChanged()
    {
        //TODO
    }

    [Fact]
    public void Deposit_Exception_NoTransactionIsAdded()
    {
        //TODO
    }
}
