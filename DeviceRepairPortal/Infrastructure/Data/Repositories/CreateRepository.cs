using Infrastructure.Data;

namespace Infrastructure.Repositories;

internal class CreateRepository<TEntity>(ApplicationDbContext context) : ICreateRepository<TEntity> where TEntity : class
{
	public async Task CreateAsync(TEntity entity, CancellationToken cancellationToken = default)
	{
		await context.Set<TEntity>().AddAsync(entity, cancellationToken);
		await context.SaveChangesAsync(cancellationToken);
	}
}