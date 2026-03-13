using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;

public class User : IdentityUser
{
	public bool AccountDeleted { get; set; }
	public bool IsRestricted { get; set; }
	public UserDetails UserDetails { get; set; } = null!;
	public RefreshToken RefreshToken { get; set; } = null!;
	public ICollection<UserChangeHistory> UserChangeHistories { get; set; } = [];
}