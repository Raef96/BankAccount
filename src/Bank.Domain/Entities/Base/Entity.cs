namespace Bank.Domain.Entities.Base;
public class Entity : BaseEntity<int>
{

}

public class BaseEntity<T>
{
    public virtual T Id { get; set; }
}

