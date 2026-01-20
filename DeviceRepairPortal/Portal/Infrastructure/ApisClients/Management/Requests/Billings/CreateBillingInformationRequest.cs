namespace Infrastructure.ApisClients.Management.Requests.Billings;

public record CreateBillingInformationRequest(Guid JobId, decimal Amount, int? DiscountId);