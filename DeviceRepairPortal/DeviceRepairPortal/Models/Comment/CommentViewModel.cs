namespace DeviceRepairPortal.Models.Comment;

public record CommentViewModel : CreatedInformationsViewModel
{
    public string Content { get; init; }
}