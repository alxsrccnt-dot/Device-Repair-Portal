using MediatR;

namespace Application.Management.Comments;

public record CreateCommentCommand(CreateCommentRequest Request) : IRequest;