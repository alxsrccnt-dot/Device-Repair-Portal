namespace Domain.Entities.Base;

public class Entity<T> : BaseEntity<T>
{
    public Entity() { }

    public Entity(string createdBy, string usernameOfCreatedBy, DateTime createdAt)
    {
        CreateAt = createdAt;
        CreatedBy = createdBy;
        UsernameOfCreatedBy = usernameOfCreatedBy;
    }

    public string CreatedBy { get; set; }
    public string UsernameOfCreatedBy { get; set; }
    public DateTime CreateAt { get; set; }
}
