using Bank.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Bank.Infrastructure.Persistance
{
    public class BankDbContext : DbContext
    {
        public BankDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
     

        public DbSet<Account> Accounts => Set<Account>();
        public DbSet<Card> Cards => Set<Card>();
        public DbSet<Transaction> Transactions => Set<Transaction>();
    }
}
