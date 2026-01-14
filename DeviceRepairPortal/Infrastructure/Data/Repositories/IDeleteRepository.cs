namespace Infrastructure.Repositories;

public interface IDeleteRepository<T>
{
	Task DeleteAsync(T entity, CancellationToken cancellationToken = default);
}
