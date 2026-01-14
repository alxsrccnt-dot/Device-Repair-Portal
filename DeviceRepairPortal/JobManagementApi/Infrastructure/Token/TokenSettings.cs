namespace JobManagementApi.Infrastructure.Token;

public record TokenSettings(string Secret, string Issuer, string Audience, int ExpirationInMinutes);