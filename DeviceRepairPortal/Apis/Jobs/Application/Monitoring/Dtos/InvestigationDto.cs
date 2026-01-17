using Application.Monitoring.Dtos.Common;

namespace Application.Monitoring.Dtos;

public class InvestigationDto : CreatedInformationsDto
{
    public string Conclusion { get; init; }
    public string Description { get; init; }
    public ICollection<IssueDto> Issues { get; init; } = [];
}