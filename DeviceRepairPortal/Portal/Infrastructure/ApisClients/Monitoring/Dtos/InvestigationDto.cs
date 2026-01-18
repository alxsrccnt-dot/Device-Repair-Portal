using Infrastructure.ApisClients.Monitoring.Dtos.Common;

namespace Infrastructure.ApisClients.Monitoring.Dtos;

public record InvestigationDto : CreatedInformationsDto
{
    public string Conclusion { get; init; }
    public string Description { get; init; }
    public ICollection<IssueDto> Issues { get; init; } = [];
}