using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace TechChallenge.WebAPI.Models;

public class UserViewModel
{
    [Required(AllowEmptyStrings = false)]
    [StringLength(maximumLength: 30, MinimumLength = 5)]
    [SwaggerSchema(Description = "Nome de usuário.")]
    public required string Username { get; set; }

    [Required(AllowEmptyStrings = false)]
    [StringLength(maximumLength: 30, MinimumLength = 5)]
    [SwaggerSchema(Description = "Senha de acesso.")]
    public required string Password { get; set; }
}