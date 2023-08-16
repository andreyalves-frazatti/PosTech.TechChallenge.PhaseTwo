using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;
using TechChallenge.Application.UseCases.CreateUser;

namespace TechChallenge.WebAPI.Models;

public class CreateUserViewModel
{
    [Required(AllowEmptyStrings = false)]
    [StringLength(maximumLength: 30, MinimumLength = 5)]
    [SwaggerSchema(Description = "Your username.")]
    public required string Username { get; set; }

    [Required(AllowEmptyStrings = false)]
    [StringLength(maximumLength: 200, MinimumLength = 5)]
    [SwaggerSchema(Description = "Your password.")]
    public required string Password { get; set; }

    [Required(AllowEmptyStrings = false)]
    [StringLength(maximumLength: 200, MinimumLength = 5)]
    [SwaggerSchema(Description = "Permission type. Example: Admin or Reader.")]
    public required string Role { get; set; }

    public CreateUserInput MapToInput()
    {
        return new CreateUserInput()
        {
            Username = Username,
            Password = Password,
            Role = Role
        };
    }
}