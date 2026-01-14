namespace Domain.Entities.Base;

public class BaseEntity<T>(string createdBy, DateTime createdAt) : Entity<T>
{
	public string CreatedBy { get; set; } = createdBy;
	public DateTime CreateAt { get; set; } = createdAt;
}
