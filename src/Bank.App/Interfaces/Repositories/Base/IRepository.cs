using Bank.Domain.Entities.Base;

namespace Bank.App.Interfaces.Repositories.Base;

public interface IRepository<TEntity> : IBaseRepository<TEntity, Guid>
    where TEntity : Entity
{

}

public interface IBaseRepository<TEntity, T>
    where TEntity : BaseEntity<T>
{
    TEntity Get(T id);
    List<TEntity> GetAll();
    bool Add(params TEntity[] entities);
    bool Update(params TEntity[] entities);
    bool Remove(params TEntity[] entities);
}
