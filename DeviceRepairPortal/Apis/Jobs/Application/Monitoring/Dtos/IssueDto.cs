using Application.Monitoring.Dtos.Common;

namespace Application.Monitoring.Dtos;

public class IssueDto : BaseDto<int>
{
    public string DevicePiece { get; init; }
    public string Description { get; init; }
    public decimal Price { get; init; }
}