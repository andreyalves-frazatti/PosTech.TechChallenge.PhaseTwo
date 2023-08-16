using MediatR;

namespace TechChallenge.Application.UseCases.CreateNews;

public interface ICreateNewsUseCase
    : IRequestHandler<CreateNewsInput>
{ }
