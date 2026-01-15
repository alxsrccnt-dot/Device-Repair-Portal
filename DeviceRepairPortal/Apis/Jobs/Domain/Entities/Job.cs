using Domain.Entities.Base;

namespace Domain.Entities;

public class Job : BaseEntity<Guid>
{
    public Job() { }

    public Job(string createdBy, DateTime createdAt)
        : base(createdBy, createdAt){}

    public DateTime? EndDate { get; set; }

    public Ticket Ticket { get; set; } = null!;
    public Investigation? Investigation { get; set; }
    public BillingInformation? BillingInformation { get; set; }

    public ICollection<Comment> Comments { get; set; } = [];
    public ICollection<Phase> Phases { get; set; } = [];
}