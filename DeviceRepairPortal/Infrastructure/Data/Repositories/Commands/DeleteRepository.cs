using Infrastructure.Data;

namespace Infrastructure.Data.Repositories.Commands;

internal class DeleteRepository<T>(ApplicationDbContext context) : IDeleteRepository<T> where T : class
{
	public async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
	{
		context.Set<T>().Remove(entity);
		await context.SaveChangesAsync(cancellationToken);
	}
}