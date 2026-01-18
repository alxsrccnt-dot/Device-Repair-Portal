using DeviceRepairPortal.Models.Issue;

namespace DeviceRepairPortal.Models.Ticket;

public class CreateTicketViewModel
{
    public string Description { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public string SerialNumber { get; set; } = string.Empty;

    public List<int> SelectedIssueIds { get; set; } = new();
    public List<IssueViewModel> AvailableIssues { get; set; } = new();
}