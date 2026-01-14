namespace Domain.Entities.Base;

public class BaseEntity<T> : Entity<T>
{
    public BaseEntity() { }

    public BaseEntity(string createdBy, DateTime createdAt)
    {
        CreateAt = createdAt;
        CreatedBy = createdBy;
    }

    public string CreatedBy { get; set; }
	public DateTime CreateAt { get; set; }
}
