using Domain.Entities;

namespace Application.Shared.Identity.Token;

public interface IRefreshTokenService
{
    Task<string> GenerateAsync(string userId, CancellationToken cancellationToken);
    Task ValidateAsync(RefreshToken refreshToken, CancellationToken cancellationToken);
    Task<string?> ValidateUserSesionAsync(string token, CancellationToken cancellationToken);
    Task RevokeAsync(string token, CancellationToken cancellationToken);
}