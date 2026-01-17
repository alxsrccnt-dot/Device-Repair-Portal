using Infrastructure.ApisClients.Monitoring.Dtos.Common;

namespace Infrastructure.ApisClients.Monitoring.Dtos;

public record BillingInformationDto : CreatedInformationsDto
{
    public decimal Amount { get; init; }
    public DiscountDto? Discount { get; init; }
}