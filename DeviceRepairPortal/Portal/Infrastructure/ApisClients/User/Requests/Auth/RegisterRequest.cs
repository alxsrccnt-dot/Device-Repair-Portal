namespace Infrastructure.ApisClients.User.Requests.Auth;

public sealed record RegisterRequest(
	string UserName,
	string Email,
	string Password
);
