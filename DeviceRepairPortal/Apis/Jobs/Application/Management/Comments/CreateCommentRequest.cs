namespace Application.Management.Comments;

public record CreateCommentRequest(Guid JobId, string Comment);