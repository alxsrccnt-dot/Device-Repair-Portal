using Domain.Entities.Base;

namespace Domain.Entities;

public class Task(string description, int deviceId, string createdBy, DateTime createdAt)
    : BaseEntity<Guid>(createdBy, createdAt)
{
    public string Description { get; set; } = description;
    public int DeviceId { get; set; } = deviceId;
    public Device Device { get; set; } = null!;
    public Guid? JobId { get; set; }
    public ICollection<Issue> issues { get; set; } = [];
}