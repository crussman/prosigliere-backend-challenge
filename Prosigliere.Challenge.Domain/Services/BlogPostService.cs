using Prosigliere.Challenge.Domain.Entities;
using Prosigliere.Challenge.Domain.ValueObjects;

namespace Prosigliere.Challenge.Domain.Services;

public interface IBlogPostService
{
    Task<IEnumerable<BlogPost>> GetAsync(CancellationToken cancellationToken);
    Task<BlogPost?> GetAsync(Guid id, CancellationToken cancellationToken);
    Task<BlogPost> AddAsync(BlogPostCreationData blogPostCreationData, CancellationToken cancellationToken);
    Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken);
}
