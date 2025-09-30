using Prosigliere.Challenge.Domain.Entities;
using Prosigliere.Challenge.Domain.Repositories;

namespace Prosigliere.Challenge.Infrastructure.Repositories;

public class CommentRepository(AppDbContext context)
    : RepositoryBaseAsync<Comment>(context), ICommentRepository
{ }
