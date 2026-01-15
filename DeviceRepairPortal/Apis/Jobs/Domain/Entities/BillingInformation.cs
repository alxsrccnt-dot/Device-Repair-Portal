using Domain.Entities.Base;

namespace Domain.Entities;

public class BillingInformation
    : Entity<Guid>
{
    public BillingInformation() { }

    public BillingInformation(Guid jobId, decimal amount, string createdBy, string usernameOfCreatedBy, DateTime createdAt)
        : base(createdBy, usernameOfCreatedBy, createdAt)
    {
        JobId = jobId;
        Amount = amount;
    }

    public decimal Amount { get; set; }
    public Guid JobId { get; set; }
    public Job Job { get; set; } = null!;
    public int? DIscountId { get; set; }
    public Discount? Discount { get; set; }
}