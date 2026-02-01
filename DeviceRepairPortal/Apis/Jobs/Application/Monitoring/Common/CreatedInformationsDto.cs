namespace Application.Monitoring.Common;

public class CreatedInformationsDto
{
    public required string CreatedBy { get; init; }
    public DateTime CreateAt { get; init; }
}