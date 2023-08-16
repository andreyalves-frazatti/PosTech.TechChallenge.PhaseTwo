using FluentValidation;

namespace TechChallenge.Application.UseCases.CreateUser;

public class CreateUserInputValidator : AbstractValidator<CreateUserInput>
{
    public CreateUserInputValidator()
    {
        RuleFor(c => c.Username)
            .Length(5, 30);

        RuleFor(c => c.Password)
            .Length(5, 200);

        var roles = new List<string> { "Admin", "Reader" };

        RuleFor(c => c.Role)
            .Must(c => roles.Contains(c));
    }
}