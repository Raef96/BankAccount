using Bank.Domain.Entities.Base;
using Bank.App.Interfaces.Repositories.Base;

namespace Bank.Infrastructure.Persistance.Base;

internal class Repository<TEntity> : IRepository<TEntity>
    where TEntity : Entity
{
    protected readonly BankDbContext _dbContext;
    public Repository(BankDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public virtual bool Add(TEntity entity)
    {
        try
        {
            _dbContext.Add(entity);
            _dbContext.SaveChanges();
            return true;
        }
        catch
        {
            // TODO: log error
        }

        return false;
    }

    public TEntity Get(Guid id)
    {
        return _dbContext.Set<TEntity>()
            .Where(entity => entity.Id == id)
            .FirstOrDefault();
    }

    public List<TEntity> GetAll()
    {
        return _dbContext.Set<TEntity>().ToList();
    }
    public bool Update(TEntity entity)
    {
        try
        {
            _dbContext.Update(entity);
            _dbContext.SaveChanges();
            return true;
        }
        catch
        {
            // TODO: log error
        }

        return false;
    }
}
