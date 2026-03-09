namespace Infrastructure.Data.Repositories.Queries.Models;

public record DataWithTotalCount<T>(IEnumerable<T> Items, int TotalCount);