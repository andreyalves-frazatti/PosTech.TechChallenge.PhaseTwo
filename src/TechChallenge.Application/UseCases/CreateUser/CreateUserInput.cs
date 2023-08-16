using MediatR;

namespace TechChallenge.Application.UseCases.CreateUser;

public class CreateUserInput : IRequest
{
    public required string Username { get; init; }

    public required string Password { get; init; }

    public required string Role { get; init; }
}