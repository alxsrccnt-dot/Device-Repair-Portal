using System.Text;
using Application.Services;
using Domain.Entities;
using Infrastructure.Data.Repositories.Commands;
using Infrastructure.Data.Repositories.Queries;

namespace Application.Common.Token;

public class RefreshTokenService(IRefreshTokenReadRepository readRepository, ICurrentUser currentUser,
    ICreateRepository<RefreshToken> createRepository, IUpdateRepository<RefreshToken> updateRepository,
    int expiresInDays) : IRefreshTokenService
{
    public async Task<string> GenerateAsync(string userId)
    {
        var generatedToken = GenerateToken(userId);
        var refreshToken = new RefreshToken
        {
            Token = generatedToken,
            UserId = userId,
            CreatedAt = DateTime.UtcNow,
            ExpiresAt = DateTime.UtcNow.AddDays(expiresInDays)
        };
        
        await createRepository.CreateAsync(refreshToken);

        return generatedToken;
    }
    
    public async Task ValidateAsync(string token)
    {
        var refreshToken = await readRepository.GetRefreshTokenByTokenAsync(token);

        refreshToken.CreatedAt = DateTime.UtcNow;
        refreshToken.ExpiresAt = DateTime.UtcNow.AddDays(expiresInDays);
        
        await updateRepository.UpdateAsync(refreshToken);
    }

    public async Task<string?> CanUserLoginAsync(string token)
    {
        var refreshToken = await readRepository.GetRefreshTokenByTokenAsync(token);
        
        if (IsTokenExpired(refreshToken.ExpiresAt))
            return null;
        
        return refreshToken.UserId;
    }

    public async Task RevokeAsync(string token)
    {
        var refreshToken = await readRepository.GetRefreshTokenByTokenAsync(token);
        
        refreshToken.ExpiresAt = DateTime.UtcNow.AddHours(-1);
        refreshToken.RevokedBy = currentUser.Email;
        
        await updateRepository.UpdateAsync(refreshToken);
    }

    private bool IsTokenExpired(DateTime expiresAt)
        => expiresAt < DateTime.UtcNow;
    
    private string GenerateToken(string tokenId)
        => Convert.ToBase64String( Encoding.ASCII.GetBytes(tokenId))
            .Replace("/", "_")
            .Replace("+", "-")
            .TrimEnd();
}