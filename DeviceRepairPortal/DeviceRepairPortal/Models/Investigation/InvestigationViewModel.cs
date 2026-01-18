using DeviceRepairPortal.Models.Issue;

namespace DeviceRepairPortal.Models.Investigation;

public record InvestigationViewModel : CreatedInformationsViewModel
{
    public string Conclusion { get; init; }
    public string Description { get; init; }
    public ICollection<IssueViewModel> Issues { get; init; } = [];
}