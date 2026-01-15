using Domain.Entities.Base;

namespace Domain.Entities;

public class Investigation : Entity<int>
{
    public Investigation() { }

    public Investigation(Guid jobId, string conclusion, string description, string createdBy, string usernameOfCreatedBy, DateTime createdAt)
        : base(createdBy, usernameOfCreatedBy, createdAt)
    {
        JobId = jobId;
        Conclusion = conclusion;
        Description = description;
    }

    public Investigation(Guid jobId, string conclusion, string description, ICollection<Issue> issues,string createdBy, string usernameOfCreatedBy, DateTime createdAt)
        : this(jobId, conclusion, description, createdBy, usernameOfCreatedBy, createdAt)
    {
        Issues = issues;
    }

    public string Conclusion { get; set; }
    public string Description { get; set; }
    public Guid JobId { get; set; }
    public Job Job { get; set; } = null!;
    public ICollection<Issue> Issues { get; set; } = [];
}