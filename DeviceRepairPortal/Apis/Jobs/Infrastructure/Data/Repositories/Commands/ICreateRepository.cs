namespace Infrastructure.Data.Repositories.Commands;

public interface ICreateRepository<T>
{
	Task CreateAsync(T entity, CancellationToken cancellationToken = default);
}
