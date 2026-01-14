namespace Infrastructure.Repositories;

public interface IReadRepository<T>
{
	Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
}