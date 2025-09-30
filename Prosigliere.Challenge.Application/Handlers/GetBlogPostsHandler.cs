using AutoMapper;

using MediatR;

using Prosigliere.Challenge.Application.Dtos;
using Prosigliere.Challenge.Application.Queries;
using Prosigliere.Challenge.Domain.Services;

namespace Prosigliere.Challenge.Application.Handlers;

public class GetBlogPostsHandler(IBlogPostService blogPostService, IMapper mapper) :
    IRequestHandler<GetBlogPosts, IEnumerable<BlogPostDto>>
{
    private readonly IBlogPostService _blogPostService = blogPostService
        ?? throw new ArgumentNullException(nameof(blogPostService));
    private readonly IMapper _mapper = mapper
        ?? throw new ArgumentNullException(nameof(mapper));

    public async Task<IEnumerable<BlogPostDto>> Handle(GetBlogPosts _, CancellationToken cancellationToken)
    {
        var blogPosts = await _blogPostService.GetAsync(cancellationToken);

        return _mapper.Map<IEnumerable<BlogPostDto>>(blogPosts);
    }
}