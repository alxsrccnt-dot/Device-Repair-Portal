using Infrastructure.ApisClients.Monitoring.Dtos.Common;

namespace Infrastructure.ApisClients.Monitoring.Dtos;

public record CommentDto : CreatedInformationsDto
{
    public string Content { get; init; }
}
