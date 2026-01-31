using Application.Monitoring.Dtos.Common;

namespace Application.Monitoring.Dtos;

public class CommentDto : CreatedInformationsDto
{
    public required string Content { get; init; }
}
