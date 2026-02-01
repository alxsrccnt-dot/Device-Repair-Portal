using Application.Monitoring.Common;
using Application.Monitoring.Issues.Dtos;

namespace Application.Monitoring.Jobs.Dtos;

public class InvestigationDto : CreatedInformationsDto
{
    public required string Conclusion { get; init; }
    public string? Description { get; init; }
    public ICollection<IssueDto> KnownIssues { get; init; } = [];
}