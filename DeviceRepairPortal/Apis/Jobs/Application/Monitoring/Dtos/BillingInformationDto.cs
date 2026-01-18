using Application.Monitoring.Dtos.Common;

namespace Application.Monitoring.Dtos;

public class BillingInformationDto : CreatedInformationsDto
{
    public decimal Amount { get; init; }
    public DiscountDto? Discount { get; init; }
}