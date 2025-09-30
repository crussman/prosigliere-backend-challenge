using MediatR;

using Microsoft.AspNetCore.Mvc;

using Prosigliere.Challenge.Application.Commands;
using Prosigliere.Challenge.Application.Dtos;
using Prosigliere.Challenge.Application.Queries;

namespace Prosigliere.Challenge.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostsController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<BlogPostDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(new GetBlogPosts(), cancellationToken));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(BlogPostDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetById([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(new GetBlogPost(id), cancellationToken));
    }

    [HttpPost]
    [ProducesResponseType(typeof(BlogPostDto), StatusCodes.Status201Created)]
    public async Task<IActionResult> Create([FromBody] CreateBlogPost request, CancellationToken cancellationToken)
    {
        return StatusCode(StatusCodes.Status201Created, await _mediator.Send(request, cancellationToken));
    }

    [HttpPost("{id:guid}/comments")]
    [ProducesResponseType(typeof(CommentDto), StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateComment(Guid id, [FromBody] CreateComment request, CancellationToken cancellationToken)
    {
        return StatusCode(StatusCodes.Status201Created, await _mediator.Send(request with { BlogPostId = id }, cancellationToken));
    }
}
