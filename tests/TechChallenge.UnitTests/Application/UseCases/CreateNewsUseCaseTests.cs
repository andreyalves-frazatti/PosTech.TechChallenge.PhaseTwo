using AutoFixture;
using FluentValidation.Results;
using Moq;
using TechChallenge.Application.UseCases.CreateNews;
using TechChallenge.Domain.Entities;

namespace TechChallenge.UnitTests.Application.UseCases;

public class CreateNewsUseCaseTests
{
    private readonly IFixture _autoFixture;

    public CreateNewsUseCaseTests()
    {
        _autoFixture = new Fixture();
    }

    [Fact]
    public async Task Should_CreateNews_When_InputIsValid()
    {
        /* arrange */
        var input = _autoFixture.Create<CreateNewsInput>();
        var cancelationToken = new CancellationToken();

        var testFixture = new CreateNewsUseCaseFixture();

        testFixture
            .MockValidator
            .Setup(c => c.ValidateAsync(input, cancelationToken))
            .ReturnsAsync(new ValidationResult());

        /* act */
        await testFixture.UseCaseInstance.Handle(input, cancelationToken);

        /* assert */
        testFixture
            .MockNewsRepository
            .Verify(c => c.InsertAsync(
                It.Is<News>(c
                    => c.Id != Guid.Empty
                    && c.Title == input.Title
                    && c.Description == input.Description
                    && c.Date != default
                    && c.Date.Date == DateTime.Now.Date
                    && c.Author != default
                    && c.Author == input.Author),
                cancelationToken), Times.Once);
    }

    [Fact]
    public async Task Should_NotCreateNews_When_InputIsInvalid()
    {
        /* arrange */
        var input = _autoFixture.Create<CreateNewsInput>();
        var cancelationToken = new CancellationToken();

        var testFixture = new CreateNewsUseCaseFixture();

        var failures = _autoFixture.CreateMany<ValidationFailure>();
        
        testFixture
            .MockValidator
            .Setup(c => c.ValidateAsync(input, cancelationToken))
            .ReturnsAsync(new ValidationResult(failures));

        /* act */
        await testFixture.UseCaseInstance.Handle(input, cancelationToken);

        /* assert */
        testFixture
            .MockNewsRepository
            .Verify(c => c.InsertAsync(
                It.IsAny<News>(),
                It.IsAny<CancellationToken>()), Times.Never);
    }
}