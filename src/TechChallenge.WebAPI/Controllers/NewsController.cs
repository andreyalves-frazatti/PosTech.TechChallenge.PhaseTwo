using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TechChallenge.Application.Queries;
using TechChallenge.Application.UseCases.CreateNews;
using TechChallenge.Domain.Entities;
using TechChallenge.WebAPI.Models;

namespace TechChallenge.WebAPI.Controllers
{
    [Route("api/news")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly INewsQueries _newsQueries;

        public NewsController(IMediator mediator, INewsQueries newsQueries)
        {
            _mediator = mediator;
            _newsQueries = newsQueries;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [SwaggerOperation(Summary = "Endpoint that allows the registration of news.")]
        [SwaggerResponse(StatusCodes.Status202Accepted)]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> AddAsync([FromBody] CreateNewsViewModel viewModel, CancellationToken cancellationToken)
        {
            CreateNewsInput input = viewModel.MapToInput();

            await _mediator.Send(input, cancellationToken);

            return Accepted();
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Reader")]
        [SwaggerOperation(Summary = "Endpoint that makes it possible to get all the news.")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<NewsViewModel>))]
        [SwaggerResponse(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            IEnumerable<News> news = await _newsQueries.GetAllAsync(cancellationToken);

            if (!Enumerable.Any(news))
            {
                return NoContent();
            }

            IEnumerable<NewsViewModel> viewModels = NewsViewModel.MapToViewModel(news);

            return Ok(viewModels);
        }
    }
}