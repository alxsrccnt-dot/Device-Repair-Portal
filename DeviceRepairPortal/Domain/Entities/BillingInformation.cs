using Domain.Entities.Base;

namespace Domain.Entities;

public class BillingInformation(Guid jobId, decimal amount, string createdBy, DateTime createdAt)
    : BaseEntity<Guid>(createdBy, createdAt)
{
    public decimal Ammount { get; set; } = amount;

    public Guid JobId { get; set; } = jobId;
    public Job Job { get; set; } = null!;
}