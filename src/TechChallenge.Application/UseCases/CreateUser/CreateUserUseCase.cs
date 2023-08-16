using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Repositories;

namespace TechChallenge.Application.UseCases.CreateUser;

public class CreateUserUseCase : IRequestHandler<CreateUserInput>
{
    private readonly IValidator<CreateUserInput> _validator;
    private readonly IUserRepository _userRepository;
    private readonly ILogger<CreateUserUseCase> _logger;

    public CreateUserUseCase
    (
        IValidator<CreateUserInput> validator,
        IUserRepository userRepository,
        ILogger<CreateUserUseCase> logger
    )
    {
        _validator = validator;
        _userRepository = userRepository;
        _logger = logger;
    }

    public async Task Handle(CreateUserInput request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            _logger.LogWarning("Invalid input. Errors: {@Errors}", validationResult.Errors);
            return;
        }

        var user = User.Factory.NewUser(
            request.Username,
            request.Password,
            request.Role
        );

        await _userRepository.InsertAsync(user, cancellationToken);
    }
}