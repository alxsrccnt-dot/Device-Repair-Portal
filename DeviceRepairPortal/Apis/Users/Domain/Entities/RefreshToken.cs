using Domain.Common;

namespace Domain.Entities;

public class RefreshToken : BaseEntity<Guid>
{
    public required string Token  { get; init; }
    public DateTime CreatedAt { get; set; }
    public DateTime ExpiresAt { get; set; }

    public string? RevokedBy { get; set; }
    
    public required string UserId  { get; init; }
    public User? User { get; init; }
}