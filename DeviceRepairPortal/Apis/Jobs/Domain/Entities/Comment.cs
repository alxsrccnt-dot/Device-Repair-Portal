using Domain.Entities.Base;

namespace Domain.Entities;

public class Comment : BaseEntity<int>
{
    public Comment() { }

    public Comment(Guid jobId, string content, string createdBy, DateTime createdAt)
        : base(createdBy, createdAt)
    {
        JobId = jobId;
        Content = content;
    }

    public string Content { get; set; }
    public Guid JobId { get; set; }
    public Job Job { get; set; } = null!;
}