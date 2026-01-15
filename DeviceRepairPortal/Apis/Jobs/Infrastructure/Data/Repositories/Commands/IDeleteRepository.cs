namespace Infrastructure.Data.Repositories.Commands;

public interface IDeleteRepository<T>
{
	Task DeleteAsync(T entity, CancellationToken cancellationToken = default);
}
