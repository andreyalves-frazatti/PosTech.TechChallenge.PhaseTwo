using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TechChallenge.Domain.Repositories;
using TechChallenge.WebAPI.Models;
using TechChallenge.WebAPI.Security;

namespace TechChallenge.WebAPI.Controllers;

[Route("api/login")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly SecurityService _securityService;

    public LoginController(IUserRepository userRepository, SecurityService securityService)
    {
        _userRepository = userRepository;
        _securityService = securityService;
    }

    [HttpPost]
    [AllowAnonymous]
    [SwaggerOperation(Summary = "Endpoint that enables access token generation.")]
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(string))]
    [SwaggerResponse(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> AuthenticateAsync([FromBody] UserViewModel model, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetAsync(model.Username, model.Password, cancellationToken);

        if (user is null)
        {
            return Unauthorized();
        }

        var token = _securityService.GenerateToken(user);

        return Ok(token);
    }
}
