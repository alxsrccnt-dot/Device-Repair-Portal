namespace Infrastructure.ApisClients.Management.Requests.Billings;

public record CreateBillingInformationRequest
{
    public Guid JobId { get; set; }
    public decimal Amount { get; set; }
    public int? DiscountId { get; set; }
}