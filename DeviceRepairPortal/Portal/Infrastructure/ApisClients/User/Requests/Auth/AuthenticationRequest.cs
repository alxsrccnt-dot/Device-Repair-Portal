namespace Infrastructure.ApisClients.User.Requests.Auth;

public record AuthenticationRequest(string Email, string Password);