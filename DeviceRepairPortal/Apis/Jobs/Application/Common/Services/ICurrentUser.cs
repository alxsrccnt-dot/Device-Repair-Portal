namespace Application.Common.Services;

public interface ICurrentUser
{
	bool IsAuthenticated { get; }
	string? UserId { get; }
	string? Email { get; }
	string? UserName { get; }
}
