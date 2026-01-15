using Infrastructure.Data;

namespace Infrastructure.Data.Repositories.Queries;

internal class ReadRepository<TEntity>(ApplicationDbContext context) : IReadRepository<TEntity> where TEntity : class
{
    public async Task<TEntity?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        => await context.Set<TEntity>().FindAsync(new object[] { id }, cancellationToken);
    public async Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        => await context.Set<TEntity>().FindAsync(new object[] { id }, cancellationToken);
}