using AutoMapper;

using MediatR;

using Prosigliere.Challenge.Application.Commands;
using Prosigliere.Challenge.Application.Dtos;
using Prosigliere.Challenge.Domain.Resources;
using Prosigliere.Challenge.Domain.Services;
using Prosigliere.Challenge.Domain.ValueObjects;

namespace Prosigliere.Challenge.Application.Handlers;

public class CreateCommentHandler(
    ICommentService commentService,
    IMapper mapper,
    IBlogPostService blogPostService) : IRequestHandler<CreateComment, CommentDto>
{
    private readonly ICommentService _commentService = commentService
        ?? throw new ArgumentNullException(nameof(commentService));
    private readonly IBlogPostService _blogPostService = blogPostService
        ?? throw new ArgumentNullException(nameof(blogPostService));
    private readonly IMapper _mapper = mapper
        ?? throw new ArgumentNullException(nameof(mapper));

    public async Task<CommentDto> Handle(CreateComment request, CancellationToken cancellationToken)
    {
        if (!await _blogPostService.ExistsAsync(request.BlogPostId, cancellationToken))
            throw new KeyNotFoundException(Messages.BlogPostNotFound);

        var creationData = _mapper.Map<CommentCreationData>(request);
        var createdComment = await _commentService.AddAsync(creationData, cancellationToken);

        return _mapper.Map<CommentDto>(createdComment);
    }
}