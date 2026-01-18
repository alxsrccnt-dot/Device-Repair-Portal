using DeviceRepairPortal.Models.BillingInformation;
using DeviceRepairPortal.Models.Comment;
using DeviceRepairPortal.Models.Investigation;
using DeviceRepairPortal.Models.Phase;

namespace DeviceRepairPortal.Models.Job;

public record JobViewModel : CreatedInformationsViewModel
{
    public DateTime? EndDate { get; init; }
    public JobTicketViewModel Ticket { get; init; }
    public InvestigationViewModel? Investigation { get; init; }
    public BillingInformationViewModel? BillingInformation { get; init; }

    public ICollection<CommentViewModel> Comments { get; set; } = [];
    public ICollection<PhaseViewModel> Phases { get; set; } = [];
}