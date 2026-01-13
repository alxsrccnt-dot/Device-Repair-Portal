namespace Application.Common.Token;

public record TokenSettings(string Secret, string Issuer, string Audience, int ExpirationInMinutes);