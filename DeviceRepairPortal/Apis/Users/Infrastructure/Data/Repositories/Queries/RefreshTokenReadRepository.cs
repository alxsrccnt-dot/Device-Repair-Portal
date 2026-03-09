using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories.Queries;

internal class RefreshTokenReadRepository(ApplicationDbContext context) :IRefreshTokenReadRepository
{
    public async Task<RefreshToken> GetRefreshTokenByTokenAsync(string token, CancellationToken cancellationToken)
        => await context.RefreshTokens
            .SingleAsync(rt => rt.Token == token, cancellationToken);
}