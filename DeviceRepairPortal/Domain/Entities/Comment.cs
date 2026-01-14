using Domain.Entities.Base;

namespace Domain.Entities;

public class Comment(Guid jobId, string content, string createdBy, DateTime createdAt)
    : BaseEntity<int>(createdBy, createdAt)
{
    public string Content { get; set; } = content;
    public Guid JobId { get; set; } = jobId;
    public Job Job { get; set; } = null!;
}