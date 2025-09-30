using AutoMapper;

using MediatR;

using Prosigliere.Challenge.Application.Dtos;
using Prosigliere.Challenge.Application.Queries;
using Prosigliere.Challenge.Domain.Resources;
using Prosigliere.Challenge.Domain.Services;

namespace Prosigliere.Challenge.Application.Handlers;

public class GetBlogPostHandler(IBlogPostService blogPostService, IMapper mapper) :
    IRequestHandler<GetBlogPost, BlogPostDto>
{
    private readonly IBlogPostService _blogPostService = blogPostService
        ?? throw new ArgumentNullException(nameof(blogPostService));
    private readonly IMapper _mapper = mapper
        ?? throw new ArgumentNullException(nameof(mapper));

    public async Task<BlogPostDto> Handle(GetBlogPost request, CancellationToken cancellationToken)
    {
        var blogPost = await _blogPostService.GetAsync(request.Id, cancellationToken)
            ?? throw new KeyNotFoundException(Messages.BlogPostNotFound);

        return _mapper.Map<BlogPostDto>(blogPost);
    }
}