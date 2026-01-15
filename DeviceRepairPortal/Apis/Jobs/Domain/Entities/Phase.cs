using Domain.Entities.Base;
using Domain.Enums;

namespace Domain.Entities;

public class Phase : Entity<int>
{
    public Phase() { }

    public Phase(Guid jobId, string createdBy, string usernameOfCreatedBy, DateTime createdAt)
        : base(createdBy, usernameOfCreatedBy, createdAt)
    {
        JobId = jobId;
    }

    public State State { get; set; }
    public Guid JobId { get; set; }
    public Job Job { get; set; } = null!;
}