namespace CalorieTracker.Domain.Abstract;

public abstract class DomainEntity
{
    public int Id { get; private set; }
    public DateTime CreatedOn { get; protected set; }
    public DateTime? DeletedOn { get; protected set; } = null;

    public void Delete()
    {
        DeletedOn = DateTime.UtcNow;
    }
}
