namespace Application.Shared.Identity.Token;

public record TokenSettings(string Secret, string Issuer, string Audience, int ExpirationInMinutes, int RefreshTokenExpirationInDays);