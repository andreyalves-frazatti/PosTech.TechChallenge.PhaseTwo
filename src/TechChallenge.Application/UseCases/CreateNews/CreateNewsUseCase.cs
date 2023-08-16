using FluentValidation;
using Microsoft.Extensions.Logging;
using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Repositories;

namespace TechChallenge.Application.UseCases.CreateNews;

public class CreateNewsUseCase : ICreateNewsUseCase
{
    private readonly IValidator<CreateNewsInput> _validator;
    private readonly INewsRepository _newsRepository;
    private readonly ILogger<CreateNewsUseCase> _logger;

    public CreateNewsUseCase
    (
        INewsRepository newsRepository,
        IValidator<CreateNewsInput> validator,
        ILogger<CreateNewsUseCase> logger
    )
    {
        _newsRepository = newsRepository;
        _validator = validator;
        _logger = logger;
    }

    public async Task Handle(CreateNewsInput request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            _logger.LogWarning("Invalid input. Errors: {@Errors}", validationResult.Errors);
            return;
        }

        var news = News.Factory.NewPost(
            request.Title,
            request.Description,
            DateTime.Now,
            request.Author);

        await _newsRepository.InsertAsync(news, cancellationToken);
    }
}