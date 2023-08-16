using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TechChallenge.Application.UseCases.CreateUser;
using TechChallenge.WebAPI.Models;

namespace TechChallenge.WebAPI.Controllers;

[Route("api/user")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [AllowAnonymous]
    [SwaggerOperation(Summary = "Endpoint that allows the registration of user.")]
    [SwaggerResponse(StatusCodes.Status202Accepted)]
    [SwaggerResponse(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> AddAsync([FromBody] CreateUserViewModel viewModel, CancellationToken cancellationToken)
    {
        CreateUserInput input = viewModel.MapToInput();

        await _mediator.Send(input, cancellationToken);

        return Accepted();
    }

}