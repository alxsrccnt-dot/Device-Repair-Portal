namespace Application.Identity.Shared;

public record AuthResponse(string AccessToken, string RefreshToken);