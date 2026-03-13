using Domain.Common;

namespace Domain.Entities;

public class UserChangeHistory : BaseEntity<int>
{
	public required string ChangedFieldOldValue { get; set; }
	public required string ChangedFieldName { get; set; }
	public DateTime ChangedAt { get; set; }

	public required string UserId { get; set; }
	public required User User { get; set; }
}