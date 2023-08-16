namespace TechChallenge.Domain.Entities;

public class User
{
    public required Guid Id { get; init; }

    public required string Username { get; init; }

    public required string Password { get; init; }

    public required string Role { get; init; }

    public static class Factory
    {
        public static User NewUser(string username, string password, string role)
        {
            return new()
            {
                Id = Guid.NewGuid(),
                Username = username,
                Password = password,
                Role = role
            };
        }
    }
}