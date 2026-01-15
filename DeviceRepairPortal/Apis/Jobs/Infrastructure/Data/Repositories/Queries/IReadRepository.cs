namespace Infrastructure.Data.Repositories.Queries;

public interface IReadRepository<T>
{
    Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}