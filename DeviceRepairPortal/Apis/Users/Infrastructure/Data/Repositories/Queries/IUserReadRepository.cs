using Domain.Entities;

namespace Infrastructure.Data.Repositories.Queries;

public interface IUserReadRepository
{
    public Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken = default);
}