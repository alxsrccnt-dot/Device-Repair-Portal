using Domain.Common;

namespace Domain.Entities;

public class UserChangeHistory : BaseEntity<int>
{
	public string ChangedFieldOldValue { get; set; } = null!;
	public string ChangedFieldName { get; set; } = null!;
	public DateOnly ChangetAt { get; set; }
	public string UserId { get; set; } = null!;
	public User User { get; set; } = null!;
}