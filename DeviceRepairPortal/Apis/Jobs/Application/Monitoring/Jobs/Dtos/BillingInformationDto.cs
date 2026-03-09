using Application.Monitoring.Common;

namespace Application.Monitoring.Jobs.Dtos;

public class BillingInformationDto : CreatedInformationsDto
{
    public decimal Amount { get; init; }
    public DiscountDto? Discount { get; init; }
}