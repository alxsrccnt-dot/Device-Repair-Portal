using Domain.Entities.Base;

namespace Domain.Entities;

public class Comment : Entity<int>
{
    public Comment() { }

    public Comment(string content, string createdBy, string usernameOfCreatedBy, DateTime createdAt)
        : base(createdBy, usernameOfCreatedBy, createdAt)
    {
        Content = content;
    }

    public Comment(Guid jobId, string content, string createdBy, DateTime createdAt)
        : base(content, createdBy, createdAt)
    {
        JobId = jobId;
    }

    public string Content { get; set; }
    public Guid JobId { get; set; }
    public Job Job { get; set; } = null!;
}