namespace DeviceRepairPortal.Models.BillingInformation;

public class CreateBillingInformationInputModel
{
    public Guid JobId { get; set; }
    public decimal Amount { get; set; }
    public int? DiscountId { get; set; }
}