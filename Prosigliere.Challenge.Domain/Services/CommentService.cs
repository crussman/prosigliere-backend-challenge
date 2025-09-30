using Prosigliere.Challenge.Domain.Entities;
using Prosigliere.Challenge.Domain.ValueObjects;

namespace Prosigliere.Challenge.Domain.Services;

public interface ICommentService
{
    Task<Comment> AddAsync(CommentCreationData commentCreationData, CancellationToken cancellationToken);
}
