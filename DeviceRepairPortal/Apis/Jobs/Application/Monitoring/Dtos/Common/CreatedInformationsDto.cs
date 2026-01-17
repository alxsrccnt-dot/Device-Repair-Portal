namespace Application.Monitoring.Dtos.Common;

public record CreatedInformationsDto
{
    public string CreatedBy { get; init; }
    public DateTime CreateAt { get; init; }
}
