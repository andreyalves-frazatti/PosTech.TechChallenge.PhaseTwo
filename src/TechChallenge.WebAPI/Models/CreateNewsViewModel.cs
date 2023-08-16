using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;
using TechChallenge.Application.UseCases.CreateNews;

namespace TechChallenge.WebAPI.Models;

public class CreateNewsViewModel
{
    [Required(AllowEmptyStrings = false)]
    [StringLength(maximumLength: 30, MinimumLength = 5)]
    [SwaggerSchema(Description = "Título da notícia.")]
    public required string Title { get; set; }

    [Required(AllowEmptyStrings = false)]
    [StringLength(maximumLength: 200, MinimumLength = 5)]
    [SwaggerSchema(Description = "Conteúdo da notícia.")]
    public required string Description { get; set; }

    [Required(AllowEmptyStrings = false)]
    [StringLength(maximumLength: 200, MinimumLength = 5)]
    [SwaggerSchema(Description = "Autor responsável pela publicação.")]
    public required string Author { get; set; }

    public CreateNewsInput MapToInput()
    {
        return new CreateNewsInput ()
        {
            Title = Title,
            Description = Description,
            Author = Author
        };
    }
}