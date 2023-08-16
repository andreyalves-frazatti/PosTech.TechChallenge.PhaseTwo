using Microsoft.EntityFrameworkCore;
using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Repositories;

namespace TechChallenge.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DatabaseContext _context;

    public UserRepository(DatabaseContext context)
    {
        _context = context;
        _context.Database.EnsureCreated();
    }

    Task<User?> IUserRepository.GetAsync(string username, string password, CancellationToken cancellationToken)
    {
        return _context.Users.FirstOrDefaultAsync(c => c.Username == username && c.Password == password, cancellationToken);
    }

    async Task IUserRepository.InsertAsync(User user, CancellationToken cancellationToken)
    {
        await _context.Users.AddAsync(user, cancellationToken);
        await _context.SaveChangesAsync();
    }
}
