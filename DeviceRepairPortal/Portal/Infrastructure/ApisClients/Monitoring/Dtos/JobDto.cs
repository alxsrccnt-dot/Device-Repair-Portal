using Infrastructure.ApisClients.Monitoring.Dtos.Common;

namespace Infrastructure.ApisClients.Monitoring.Dtos;

public record JobDto : CreatedInformationsDto
{
    public DateTime? EndDate { get; init; }
    public JobTicketDto Ticket { get; init; }
    public InvestigationDto? Investigation { get; init; }
    public BillingInformationDto? BillingInformation { get; init; }

    public ICollection<CommentDto> Comments { get; set; } = [];
    public ICollection<PhaseDto> Phases { get; set; } = [];
}