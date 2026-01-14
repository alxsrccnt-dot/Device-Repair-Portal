using Domain.Entities.Base;
using Domain.Enums;

namespace Domain.Entities;

public abstract class Phase(int jobId, string createdBy, DateTime createdAt)
    : BaseEntity<int>(createdBy, createdAt)
{
    public int JobId { get; set; } = jobId;
    public Job Job { get; set; } = null!;
    public State State { get; set; }
}