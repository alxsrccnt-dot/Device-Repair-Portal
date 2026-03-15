using Application.Monitoring.Common;

namespace Application.Monitoring.Jobs.Dtos;

public class JobDetailsDto : CreatedInformationsDto
{
    public Guid Id { get; init; }
    public DateTime? EndDate { get; init; }
    public TicketDto Ticket { get; init; }
    public InvestigationDto? Investigation { get; init; }
    public BillingInformationDto? BillingInformation { get; init; }

    public ICollection<CommentDto> Comments { get; set; } = [];
    public ICollection<PhaseDto> Phases { get; set; } = [];
}