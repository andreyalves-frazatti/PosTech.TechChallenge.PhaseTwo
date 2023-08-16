using MediatR;

namespace TechChallenge.Application.UseCases.CreateUser;

public interface ICreateUserUseCase
    : IRequestHandler<CreateUserInput>
{ }