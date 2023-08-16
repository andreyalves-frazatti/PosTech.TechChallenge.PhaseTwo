using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Repositories;

namespace TechChallenge.Application.Queries;

public class NewsQueries : INewsQueries
{
    private readonly INewsRepository _newsRepository;

    public NewsQueries(INewsRepository newsRepository)
    {
        _newsRepository = newsRepository;
    }

    Task<IEnumerable<News>> INewsQueries.GetAllAsync(CancellationToken cancellationToken)
        => _newsRepository.GetAllAsync(cancellationToken);

    Task<News?> INewsQueries.GetByIdAsync(Guid id, CancellationToken cancellationToken)
        => _newsRepository.GetByIdAsync(id, cancellationToken);
}