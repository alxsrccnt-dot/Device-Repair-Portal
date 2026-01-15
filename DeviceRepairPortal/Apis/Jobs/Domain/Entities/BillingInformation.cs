using Domain.Entities.Base;

namespace Domain.Entities;

public class BillingInformation
    : BaseEntity<Guid>
{
    public BillingInformation() { }

    public BillingInformation(Guid jobId, decimal amount, string createdBy, DateTime createdAt)
        : base(createdBy, createdAt)
    {
        JobId = jobId;
        Amount = amount;
    }

    public decimal Amount { get; set; }
    public Guid JobId { get; set; }
    public Job Job { get; set; } = null!;
}