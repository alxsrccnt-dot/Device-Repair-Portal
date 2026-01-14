namespace Infrastructure.Repositories;

public interface IUpdateRepository<T>
{
	Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
}
