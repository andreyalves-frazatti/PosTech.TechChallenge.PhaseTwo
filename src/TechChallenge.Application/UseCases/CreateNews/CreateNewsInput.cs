using MediatR;

namespace TechChallenge.Application.UseCases.CreateNews;

public class CreateNewsInput : IRequest
{
    public required string Title { get; init; }

    public required string Description { get; init; }

    public required string Author { get; init; }
}