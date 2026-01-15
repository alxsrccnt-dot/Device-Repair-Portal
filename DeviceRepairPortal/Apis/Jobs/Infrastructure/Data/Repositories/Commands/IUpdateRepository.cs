namespace Infrastructure.Data.Repositories.Commands;

public interface IUpdateRepository<T>
{
	Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
}
