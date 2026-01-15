using Domain.Entities.Base;
using Domain.Enums;

namespace Domain.Entities;

public class Phase : BaseEntity<int>
{
    public Phase() { }

    public Phase(Guid jobId, string createdBy, DateTime createdAt)
        : base(createdBy, createdAt)
    {
        JobId = jobId;
    }

    public State State { get; set; }
    public Guid JobId { get; set; }
    public Job Job { get; set; } = null!;
}