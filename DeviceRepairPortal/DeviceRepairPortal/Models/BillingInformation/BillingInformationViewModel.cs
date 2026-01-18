using DeviceRepairPortal.Models.Discount;

namespace DeviceRepairPortal.Models.BillingInformation;

public record BillingInformationViewModel : CreatedInformationsViewModel
{
    public decimal Amount { get; init; }
    public DiscountViewModel? Discount { get; init; }
}
