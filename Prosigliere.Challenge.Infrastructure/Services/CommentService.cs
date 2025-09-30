using AutoMapper;

using Prosigliere.Challenge.Domain.Entities;
using Prosigliere.Challenge.Domain.Repositories;
using Prosigliere.Challenge.Domain.Services;
using Prosigliere.Challenge.Domain.UnitOfWork;
using Prosigliere.Challenge.Domain.ValueObjects;

namespace Prosigliere.Challenge.Infrastructure.Services;

public class CommentService(ICommentRepository commentRepository,
    IMapper mapper,
    IUnitOfWorkAsync unitOfWork) : ICommentService
{
    private readonly ICommentRepository _commentRepository = commentRepository ?? throw new ArgumentNullException(nameof(commentRepository));
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    private readonly IUnitOfWorkAsync _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

    public async Task<Comment> AddAsync(CommentCreationData commentCreationData, CancellationToken cancellationToken)
    {
        var comment = _mapper.Map<Comment>(commentCreationData);

        await _commentRepository.AddAsync(comment, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return comment;
    }
}
