using Application.Monitoring.Dtos.Common;

namespace Application.Monitoring.Dtos;

public record CommentDto : CreatedInformationsDto
{
    public string Content { get; init; }
}
