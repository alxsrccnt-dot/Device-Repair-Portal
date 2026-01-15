using Domain.Entities.Base;
using System.Collections.ObjectModel;

namespace Domain.Entities;

public class Job : Entity<Guid>
{
    public Job() { }

    public Job(Guid ticketId, string createdBy, string usernameOfCreatedBy, DateTime createdAt)
        : base(createdBy, usernameOfCreatedBy, createdAt)
    {
        TicketId = ticketId;
    }

    public Job(Guid ticketId, string comment, string createdBy, string usernameOfCreatedBy, DateTime createdAt)
        : this(ticketId, createdBy, usernameOfCreatedBy, createdAt)
    {
        Comments = new Collection<Comment>()
        {
            new Comment(comment, createdBy, usernameOfCreatedBy, createdAt)
        };
    }

    public DateTime? EndDate { get; set; }

    public Guid TicketId { get; set; }
    public Ticket Ticket { get; set; } = null!;
    public Investigation? Investigation { get; set; }
    public BillingInformation? BillingInformation { get; set; }

    public ICollection<Comment> Comments { get; set; } = [];
    public ICollection<Phase> Phases { get; set; } = [];
}