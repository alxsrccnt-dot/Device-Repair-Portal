using Domain.Entities.Base;

namespace Domain.Entities;

public class Ticket : BaseEntity<Guid>
{
    public Ticket() { }

    public Ticket(string description, int deviceId, string createdBy, DateTime createdAt)
        : base(createdBy, createdAt)
    {
        Description = description;
        DeviceId = deviceId;
    }

    public string Description { get; set; }
    public int DeviceId { get; set; }
    public Device Device { get; set; }
    public Guid? JobId { get; set; }
    public Job Job { get; set; } = null!;
    public ICollection<Issue> Issues { get; set; } = [];
}