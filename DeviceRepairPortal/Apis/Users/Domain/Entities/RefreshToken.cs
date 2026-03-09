using Domain.Common;

namespace Domain.Entities;

public class RefreshToken : BaseEntity<Guid>
{
    public string Token  { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime ExpiresAt { get; set; }

    public string? RevokedBy { get; set; } = null;
    
    public string UserId  { get; set; }
    public User User { get; set; } = null!;
}