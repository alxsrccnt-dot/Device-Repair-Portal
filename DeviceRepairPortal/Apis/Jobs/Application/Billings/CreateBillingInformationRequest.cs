namespace Application.Billings;

public record CreateBillingInformationRequest(Guid JobId, decimal Amount);