using Domain.Entities.Base;

namespace Domain.Entities;

public class Ticket : Entity<Guid>
{
    public Ticket() { }

    public Ticket(string description, Device device, string createdBy, string usernameOfCreatedBy, DateTime createdAt)
        : base(createdBy, usernameOfCreatedBy, createdAt)
    {
        Description = description;
        Device = device;
    }

    public string Description { get; set; }
    public int DeviceId { get; set; }
    public Device Device { get; set; }
    public Job Job { get; set; } = null!;
    public ICollection<Issue> Issues { get; set; } = [];
}