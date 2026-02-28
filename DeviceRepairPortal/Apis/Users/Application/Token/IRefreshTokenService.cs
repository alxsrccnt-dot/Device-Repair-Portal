namespace Application.Common.Token;

public interface IRefreshTokenService
{
    Task<string> GenerateAsync(string userId);
    Task ValidateAsync(string token);
    Task<string?> CanUserLoginAsync(string token);
    Task RevokeAsync(string token);
}