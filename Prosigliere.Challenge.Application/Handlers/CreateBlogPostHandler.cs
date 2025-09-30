using AutoMapper;

using MediatR;

using Prosigliere.Challenge.Application.Commands;
using Prosigliere.Challenge.Application.Dtos;
using Prosigliere.Challenge.Domain.Services;
using Prosigliere.Challenge.Domain.ValueObjects;

namespace Prosigliere.Challenge.Application.Handlers;

public class CreateBlogPostHandler(IBlogPostService blogPostService, IMapper mapper) :
    IRequestHandler<CreateBlogPost, BlogPostDto>
{
    private readonly IBlogPostService _blogPostService = blogPostService
        ?? throw new ArgumentNullException(nameof(blogPostService));
    private readonly IMapper _mapper = mapper
        ?? throw new ArgumentNullException(nameof(mapper));

    public async Task<BlogPostDto> Handle(CreateBlogPost request, CancellationToken cancellationToken)
    {
        var creationData = _mapper.Map<BlogPostCreationData>(request);
        var createdBlogPost = await _blogPostService.AddAsync(creationData, cancellationToken);

        return _mapper.Map<BlogPostDto>(createdBlogPost);
    }
}