namespace Bank.App.Interfaces.Services.Base;

public interface IService<TEntity> : IBaseService<TEntity, Guid>
    where TEntity : class
{

}

public interface IBaseService<TEntity, T> where TEntity : class
{
    TEntity Add(TEntity entity);
    TEntity Get(T id);
    bool Delete(T id);
    bool Exists(T id);
}
