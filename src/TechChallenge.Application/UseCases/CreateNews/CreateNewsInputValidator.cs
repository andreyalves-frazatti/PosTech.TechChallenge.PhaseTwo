using FluentValidation;

namespace TechChallenge.Application.UseCases.CreateNews;

public class CreateNewsInputValidator : AbstractValidator<CreateNewsInput>
{
    public CreateNewsInputValidator()
    {
        RuleFor(c => c.Title)
            .Length(5, 30);

        RuleFor(c => c.Description)
            .Length(5, 200);

        RuleFor(c => c.Author)
            .Length(5, 200);
    }
}