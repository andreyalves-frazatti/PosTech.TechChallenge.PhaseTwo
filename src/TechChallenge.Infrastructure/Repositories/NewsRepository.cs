using Microsoft.EntityFrameworkCore;
using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Repositories;

namespace TechChallenge.Infrastructure.Repositories;

public class NewsRepository : INewsRepository
{
    private readonly DatabaseContext _context;

    public NewsRepository(DatabaseContext contex)
    {
        _context = contex;
        _context.Database.EnsureCreated();
    }

    async Task<IEnumerable<News>> INewsRepository.GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.News.ToListAsync(cancellationToken);
    }

    Task<News?> INewsRepository.GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return _context.News.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
    }

    async Task INewsRepository.InsertAsync(News news, CancellationToken cancellationToken)
    {
        await _context.News.AddAsync(news, cancellationToken);
        await _context.SaveChangesAsync();
    }
}