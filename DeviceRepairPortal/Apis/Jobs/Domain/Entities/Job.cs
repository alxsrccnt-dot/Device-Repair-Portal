using Domain.Entities.Base;

namespace Domain.Entities;

public class Job : Entity<Guid>
{
    public Job() { }

    public Job(Guid ticketId, string createdBy, string usernameOfCreatedBy, DateTime createdAt)
        : base(createdBy, usernameOfCreatedBy, createdAt)
    {
        TicketId = ticketId;
    }

    public DateTime? EndDate { get; set; }

    public Guid TicketId { get; set; }
    public Ticket Ticket { get; set; } = null!;
    public Investigation? Investigation { get; set; }
    public BillingInformation? BillingInformation { get; set; }

    public ICollection<Comment> Comments { get; set; } = [];
    public ICollection<Phase> Phases { get; set; } = [];
}