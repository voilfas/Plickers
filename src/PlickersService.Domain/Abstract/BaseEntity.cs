namespace PlickersService.Domain.Abstract;

public abstract class BaseEntity
{
    public Guid Id { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    protected BaseEntity()
    {
        Id = Guid.NewGuid();
    }
    
    protected BaseEntity(Guid id)
    {
        Id = id;
    }
}