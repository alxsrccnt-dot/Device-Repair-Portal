using Domain.Entities;

namespace Infrastructure.Data.Repositories.Queries;

public interface IRefreshTokenReadRepository
{
    Task<RefreshToken> GetRefreshTokenByTokenAsync(string token, CancellationToken cancellationToken = default);
}