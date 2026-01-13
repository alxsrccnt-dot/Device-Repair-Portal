using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;

public class User : IdentityUser
{
	public bool IsActive { get; set; }
	public UserDetails UserDetails { get; set; }
	public ICollection<UserChangeHistory> UserChangeHistories { get; set; } = [];
}