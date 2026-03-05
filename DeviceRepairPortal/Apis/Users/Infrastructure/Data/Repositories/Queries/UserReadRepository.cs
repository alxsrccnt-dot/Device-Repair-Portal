using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories.Queries;

internal class UserReadRepository(ApplicationDbContext context) : IUserReadRepository
{
    public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken)
        => await BaseQuery().SingleAsync(u => u.Email == email, cancellationToken);
    
    public async Task<User?> GetByIdAsync(string id, CancellationToken cancellationToken)
        => await BaseQuery().SingleAsync(u => u.Id == id, cancellationToken);

    private IQueryable<User> BaseQuery()
        => context.Users
            .Include(u => u.UserDetails)
            .Include(u => u.RefreshToken);
}