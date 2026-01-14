using Domain.Entities.Base;

namespace Domain.Entities;

public class Job(string userEmail, string createdBy, DateTime createdAt) : BaseEntity<Guid>(createdBy, createdAt)
{
    public string UserEmail { get; set; } = userEmail;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public Device Device { get; set; } = null!;
    public Investigation? Investigation { get; set; }
    public BillingInformation? BillingInformation { get; set; }

    public ICollection<Comment> Comments { get; set; } = [];
    public ICollection<Phase> Phases { get; set; } = [];
}