using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories.Queries;

internal class UserReadRepository(ApplicationDbContext context) : IUserReadRepository
{
    public async Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken)
        => await context.Users
            .Include(u => u.UserDetails)
            .Include(u => u.RefreshToken)
            .SingleAsync(u => u.Email == email, cancellationToken);
}