using Application.Monitoring.Dtos.Common;

namespace Application.Monitoring.Dtos;

public record BillingInformationDto : CreatedInformationsDto
{
    public decimal Amount { get; init; }
    public DiscountDto? Discount { get; init; }
}