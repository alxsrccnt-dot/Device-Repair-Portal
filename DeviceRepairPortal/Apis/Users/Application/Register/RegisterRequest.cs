namespace Application.Register;

public sealed record RegisterRequest(
	string UserName,
	string Email,
	string Password
);
