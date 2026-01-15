namespace DeviceRepairPortal.Infrastructure.Requests.Auth;

public sealed record RegisterRequest(
	string UserName,
	string Email,
	string Password
);
