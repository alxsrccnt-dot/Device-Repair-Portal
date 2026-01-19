using DeviceRepairPortal.Models.Issue;

namespace DeviceRepairPortal.Models.Home;

public class HomePageViewModel
{
    public IEnumerable<IssueViewModel> Issues { get; set; } = [];
}