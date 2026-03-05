namespace Application.Identity.Shared.Token;

public record TokenSettings(string Secret, string Issuer, string Audience, int ExpirationInMinutes, int RefreshTokenExpirationInDays);