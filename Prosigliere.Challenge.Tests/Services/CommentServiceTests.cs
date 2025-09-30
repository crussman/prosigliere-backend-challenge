using AutoMapper;

using Moq;

using Prosigliere.Challenge.Domain.Entities;
using Prosigliere.Challenge.Domain.Repositories;
using Prosigliere.Challenge.Domain.Services;
using Prosigliere.Challenge.Domain.UnitOfWork;
using Prosigliere.Challenge.Domain.ValueObjects;
using Prosigliere.Challenge.Infrastructure.Services;

namespace Prosigliere.Challenge.Tests.Services
{
    public class CommentServiceTests
    {
        private readonly Mock<ICommentRepository> _commentRepoMock = new();
        private readonly Mock<IMapper> _mapperMock = new();
        private readonly Mock<IUnitOfWorkAsync> _unitOfWorkMock = new();
        private readonly Mock<IBlogPostService> _blogPostServiceMock = new();

        private CommentService CreateService() => new(
            _commentRepoMock.Object,
            _mapperMock.Object,
            _unitOfWorkMock.Object);

        [Fact]
        public async Task AddAsync_CreatesAndReturnsComment_ShouldSucceed()
        {
            // Arrange
            var blogPostId = Guid.NewGuid();
            var creationData = new CommentCreationData(blogPostId, "Test comment");

            _blogPostServiceMock.Setup(s => s.ExistsAsync(blogPostId, It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            var comment = new Comment
            {
                Id = Guid.NewGuid(),
                BlogPostId = blogPostId,
                Content = "Test comment"
            };

            _mapperMock.Setup(m => m.Map<Comment>(creationData)).Returns(comment);

            _commentRepoMock.Setup(r => r.AddAsync(comment, It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            _unitOfWorkMock.Setup(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(1);

            var service = CreateService();

            // Act
            var result = await service.AddAsync(creationData, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(comment.Content, result.Content);
            Assert.Equal(comment.BlogPostId, result.BlogPostId);
        }
    }
}