using Domain.Entities.Base;
using Domain.Enums;

namespace Domain.Entities;

public class Phase : Entity<int>
{
    public Phase() { }

    public Phase(Guid jobId, State state, string createdBy, string usernameOfCreatedBy, DateTime createdAt)
        : base(createdBy, usernameOfCreatedBy, createdAt)
    {
        JobId = jobId;
        State = state;
    }

    public State State { get; set; }
    public Guid JobId { get; set; }
    public Job Job { get; set; } = null!;
}