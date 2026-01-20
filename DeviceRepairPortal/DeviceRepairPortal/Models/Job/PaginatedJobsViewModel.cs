using DeviceRepairPortal.Models.Issue;

namespace DeviceRepairPortal.Models.Job;

public class PaginatedJobsViewModel(IEnumerable<JobViewModel> data,
    int pageNumber, int pageSize, int totalCount) : PaginatedViewModel<JobViewModel>(data, pageNumber, pageSize, totalCount)
{
    public string? CreateBy { get; set; }
    public bool? InProgres { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public ICollection<IssueViewModel> AvailibleIssues { get; init; } = [];
}