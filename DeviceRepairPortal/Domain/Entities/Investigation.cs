using Domain.Entities.Base;

namespace Domain.Entities;

public class Investigation(Guid jobId, string conclusion, string description, string createdBy, DateTime createdAt)
    : BaseEntity<int>(createdBy, createdAt)
{
    public string Conclusion { get; set; } = conclusion;
    public string Description { get; set; } = description;
    public Guid JobId { get; set; } = jobId;
    public Job Job { get; set; } = null!;
    public ICollection<Issue> issues { get; set; } = [];
}