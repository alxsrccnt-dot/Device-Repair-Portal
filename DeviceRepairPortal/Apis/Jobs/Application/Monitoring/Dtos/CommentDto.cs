using Application.Monitoring.Dtos.Common;

namespace Application.Monitoring.Dtos;

public class CommentDto : CreatedInformationsDto
{
    public string Content { get; init; }
}
