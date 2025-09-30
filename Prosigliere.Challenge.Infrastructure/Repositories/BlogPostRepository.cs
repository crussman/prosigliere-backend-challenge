using Prosigliere.Challenge.Domain.Entities;
using Prosigliere.Challenge.Domain.Repositories;

namespace Prosigliere.Challenge.Infrastructure.Repositories;

public class BlogPostRepository(AppDbContext context)
    : RepositoryBaseAsync<BlogPost>(context), IBlogPostRepository
{ }
