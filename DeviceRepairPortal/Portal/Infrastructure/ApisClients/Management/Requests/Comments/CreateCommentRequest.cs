namespace Infrastructure.ApisClients.Management.Requests.Comments;

public record CreateCommentRequest(Guid JobId, string Comment);