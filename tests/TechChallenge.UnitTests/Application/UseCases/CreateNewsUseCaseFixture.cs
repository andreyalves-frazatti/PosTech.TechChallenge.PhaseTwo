using FluentValidation;
using Microsoft.Extensions.Logging;
using Moq;
using TechChallenge.Application.UseCases.CreateNews;
using TechChallenge.Domain.Repositories;

namespace TechChallenge.UnitTests.Application.UseCases;

public class CreateNewsUseCaseFixture
{
    public readonly Mock<IValidator<CreateNewsInput>> MockValidator;
    public readonly Mock<INewsRepository> MockNewsRepository;
    public readonly Mock<ILogger<CreateNewsUseCase>> MockLogger;

    public CreateNewsUseCaseFixture()
    {
        MockValidator = new Mock<IValidator<CreateNewsInput>>();
        MockNewsRepository = new Mock<INewsRepository>();
        MockLogger = new Mock<ILogger<CreateNewsUseCase>>();
    }

    public ICreateNewsUseCase UseCaseInstance
        => new CreateNewsUseCase(MockNewsRepository.Object, MockValidator.Object, MockLogger.Object);
}

