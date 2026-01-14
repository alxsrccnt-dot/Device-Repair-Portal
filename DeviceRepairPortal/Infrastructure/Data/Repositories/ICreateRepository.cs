namespace Infrastructure.Repositories;

public interface ICreateRepository<T>
{
	Task CreateAsync(T entity, CancellationToken cancellationToken = default);
}
