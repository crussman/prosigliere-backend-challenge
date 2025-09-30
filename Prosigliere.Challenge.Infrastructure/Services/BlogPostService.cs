using AutoMapper;

using Prosigliere.Challenge.Domain.Entities;
using Prosigliere.Challenge.Domain.Repositories;
using Prosigliere.Challenge.Domain.Services;
using Prosigliere.Challenge.Domain.UnitOfWork;
using Prosigliere.Challenge.Domain.ValueObjects;

namespace Prosigliere.Challenge.Infrastructure.Services;

public class BlogPostService(IBlogPostRepository blogPostRepository,
    IMapper mapper,
    IUnitOfWorkAsync unitOfWork) : IBlogPostService
{
    private readonly IBlogPostRepository _blogPostRepository = blogPostRepository ?? throw new ArgumentNullException(nameof(blogPostRepository));
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    private readonly IUnitOfWorkAsync _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

    public async Task<BlogPost> AddAsync(BlogPostCreationData blogPostCreationData, CancellationToken cancellationToken)
    {
        var blogPost = _mapper.Map<BlogPost>(blogPostCreationData);

        await _blogPostRepository.AddAsync(blogPost, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return blogPost;
    }

    public async Task<IEnumerable<BlogPost>> GetAsync(CancellationToken cancellationToken)
    {
        return await _blogPostRepository.GetAllAsync(cancellationToken, include => include.Comments);
    }

    public async Task<BlogPost?> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _blogPostRepository.GetByIdAsync(id, cancellationToken, include => include.Comments);
    }

    public async Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken)
    {
        return (await GetAsync(id, cancellationToken)) != null;
    }
}
