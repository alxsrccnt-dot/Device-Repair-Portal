using Infrastructure.Data;

namespace Infrastructure.Data.Repositories.Commands;

internal class UpdateRepository<TEntity>(ApplicationDbContext context) : IUpdateRepository<TEntity> where TEntity : class
{
	public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
	{
		context.Set<TEntity>().Update(entity);
		await context.SaveChangesAsync(cancellationToken);
	}
}