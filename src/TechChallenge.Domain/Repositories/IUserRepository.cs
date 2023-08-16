using TechChallenge.Domain.Entities;

namespace TechChallenge.Domain.Repositories;

public interface IUserRepository
{
    Task InsertAsync(User user, CancellationToken cancellationToken);

    Task<User?> GetAsync(string username, string password, CancellationToken cancellationToken);
}