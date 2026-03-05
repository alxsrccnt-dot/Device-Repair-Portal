using Domain.Entities;

namespace Infrastructure.Data.Repositories.Queries;

public interface IUserReadRepository
{
    public Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
    public Task<User?> GetByIdAsync(string id, CancellationToken cancellationToken = default);
}