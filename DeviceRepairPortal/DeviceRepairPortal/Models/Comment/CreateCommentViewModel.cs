namespace DeviceRepairPortal.Models.Comment;

public record CreateCommentViewModel : CommentViewModel
{
    public Guid JobId { get; init; }
}
