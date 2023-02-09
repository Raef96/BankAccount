namespace Bank.Domain.Entities.Base;

public class Entity : BaseEntity<Guid>
{

}
public class BaseEntity<T>
{
    public virtual T Id { get; set; }
}

