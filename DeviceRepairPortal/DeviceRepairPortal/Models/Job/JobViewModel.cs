using DeviceRepairPortal.Models.BillingInformation;
using DeviceRepairPortal.Models.Comment;
using DeviceRepairPortal.Models.Investigation;
using DeviceRepairPortal.Models.Phase;
using Infrastructure.ApisClients.Common;

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


    public bool CanAddBilling()
        => Phases.Any(p => p.State == State.Investigation);
    public bool CanAddRepair()
        => Phases.Any(p => p.State == State.Billing);
    public bool CanAddReturn()
        => Phases.Any(p => p.State == State.Repair);
}