using DeviceRepairPortal.Models.BillingInformation;
using DeviceRepairPortal.Models.Comment;
using DeviceRepairPortal.Models.Investigation;
using DeviceRepairPortal.Models.Phase;

namespace DeviceRepairPortal.Models.Job;

public record JobViewModel : CreatedInformationsViewModel
{
    public Guid Id { get; set; }
    public DateTime? EndDate { get; set; }
    public JobTicketViewModel Ticket { get; set; }
    public InvestigationViewModel? Investigation { get; set; }
    public BillingInformationViewModel? BillingInformation { get; set; }

    public ICollection<CommentViewModel> Comments { get; set; } = [];
    public ICollection<PhaseViewModel> Phases { get; set; } = [];
}