using System.Text;
using Domain.Entities;
using Infrastructure.Data.Repositories.Commands;
using Infrastructure.Data.Repositories.Queries;

namespace Application.Shared.Identity.Token;

public class RefreshTokenService(IRefreshTokenReadRepository readRepository, ICurrentUser currentUser,
    ICreateRepository<RefreshToken> createRepository, IUpdateRepository<RefreshToken> updateRepository,
    int expiresInDays) : IRefreshTokenService
{
    public async Task<string> GenerateAsync(string userId, CancellationToken cancellationToken)
    {
        var generatedToken = GenerateToken(userId);
        var refreshToken = new RefreshToken
        {
            Token = generatedToken,
            UserId = userId,
            CreatedAt = DateTime.UtcNow,
            ExpiresAt = DateTime.UtcNow.AddDays(expiresInDays)
        };
        
        await createRepository.CreateAsync(refreshToken, cancellationToken);

        return generatedToken;
    }
    
    public async Task ValidateAsync(RefreshToken refreshToken, CancellationToken cancellationToken)
    {
        refreshToken.CreatedAt = DateTime.UtcNow;
        refreshToken.ExpiresAt = DateTime.UtcNow.AddDays(expiresInDays);
        
        await updateRepository.UpdateAsync(refreshToken, cancellationToken);
    }

    public async Task<string?> ValidateUserSesionAsync(string token, CancellationToken cancellationToken)
    {
        var refreshToken = await readRepository.GetRefreshTokenByTokenAsync(token, cancellationToken);
        
        if (IsTokenExpired(refreshToken.ExpiresAt))
            return null;
        
        await ValidateAsync(refreshToken, cancellationToken);
        
        return refreshToken.UserId;
    }

    public async Task RevokeAsync(string token, CancellationToken cancellationToken)
    {
        var refreshToken = await readRepository.GetRefreshTokenByTokenAsync(token, cancellationToken);
        
        refreshToken.ExpiresAt = DateTime.UtcNow.AddHours(-1);
        refreshToken.RevokedBy = currentUser.Email;
        
        await updateRepository.UpdateAsync(refreshToken, cancellationToken);
    }

    private bool IsTokenExpired(DateTime expiresAt)
        => expiresAt < DateTime.UtcNow;
    
    private string GenerateToken(string tokenId)
        => Convert.ToBase64String( Encoding.ASCII.GetBytes(tokenId))
            .Replace("/", "_")
            .Replace("+", "-")
            .TrimEnd();
}