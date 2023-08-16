using TechChallenge.Domain.Entities;

namespace TechChallenge.Application.Queries;

public interface INewsQueries
{
    Task<IEnumerable<News>> GetAllAsync(CancellationToken cancellationToken);

    Task<News?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}

