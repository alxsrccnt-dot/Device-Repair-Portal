using Application.Monitoring.Common;

namespace Application.Monitoring.Jobs.Dtos;

public class CommentDto : CreatedInformationsDto
{
    public required string Content { get; init; }
}
