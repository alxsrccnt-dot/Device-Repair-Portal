namespace Application.Management.Billings;

public record CreateBillingInformationRequest(Guid JobId, decimal Amount);