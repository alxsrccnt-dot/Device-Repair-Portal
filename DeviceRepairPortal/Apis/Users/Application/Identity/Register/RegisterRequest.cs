namespace Application.Identity.Register;

public sealed record RegisterRequest(
	string UserName,
	string Email,
	string Password
);