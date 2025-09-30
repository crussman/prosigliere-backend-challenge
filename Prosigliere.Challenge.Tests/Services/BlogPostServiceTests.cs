using AutoMapper;

using Moq;

using Prosigliere.Challenge.Domain.Entities;
using Prosigliere.Challenge.Domain.Repositories;
using Prosigliere.Challenge.Domain.UnitOfWork;
using Prosigliere.Challenge.Infrastructure.Services;

namespace Prosigliere.Challenge.Tests.Services
{
    public class BlogPostServiceTests
    {
        private readonly Mock<IBlogPostRepository> _blogPostRepoMock = new();
        private readonly Mock<IUnitOfWorkAsync> _unitOfWorkMock = new();
        private readonly Mock<IMapper> _mapperMock = new();

        private BlogPostService CreateService() => new(
            _blogPostRepoMock.Object,
            _mapperMock.Object,
            _unitOfWorkMock.Object);

        [Fact]
        public async Task GetAsync_ReturnsAllBlogPosts_ShouldSucceed()
        {
            // Arrange
            var posts = new[]
            {
                new BlogPost { Id = Guid.NewGuid(), Title = "T1", Content = "C1" },
                new BlogPost { Id = Guid.NewGuid(), Title = "T2", Content = "C2" }
            };

            _blogPostRepoMock.Setup(r => r.GetAllAsync(It.IsAny<CancellationToken>(), It.IsAny<System.Linq.Expressions.Expression<Func<BlogPost, object>>[]>()))
                .ReturnsAsync(posts);

            var service = CreateService();

            // Act
            var result = (await service.GetAsync(CancellationToken.None)).ToList();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal(posts[0].Title, result[0].Title);
            Assert.Equal(posts[1].Title, result[1].Title);
        }

        [Fact]
        public async Task GetAsync_ById_ReturnsBlogPost_ShouldSucceed()
        {
            // Arrange
            var id = Guid.NewGuid();
            var post = new BlogPost { Id = id, Title = "T", Content = "C" };

            _blogPostRepoMock.Setup(r => r.GetByIdAsync(id, It.IsAny<CancellationToken>(), It.IsAny<System.Linq.Expressions.Expression<Func<BlogPost, object>>[]>()))
                .ReturnsAsync(post);

            var service = CreateService();

            // Act
            var result = await service.GetAsync(id, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(post.Title, result.Title);
            Assert.Equal(post.Content, result.Content);
        }

        [Fact]
        public async Task ExistsAsync_WhenBlogPostExists_ShouldReturnTrue()
        {
            // Arrange
            var id = Guid.NewGuid();
            var post = new BlogPost { Id = id, Title = "T", Content = "C" };

            _blogPostRepoMock.Setup(r => r.GetByIdAsync(id, It.IsAny<CancellationToken>(), It.IsAny<System.Linq.Expressions.Expression<Func<BlogPost, object>>[]>()))
                .ReturnsAsync(post);

            var service = CreateService();

            // Act
            var exists = await service.ExistsAsync(id, CancellationToken.None);

            // Assert
            Assert.True(exists);
        }

        [Fact]
        public async Task ExistsAsync_WhenBlogPostDoesNotExist_ShouldReturnFalse()
        {
            // Arrange
            var id = Guid.NewGuid();

            _blogPostRepoMock.Setup(r => r.GetByIdAsync(id, It.IsAny<CancellationToken>(), It.IsAny<System.Linq.Expressions.Expression<Func<BlogPost, object>>[]>()))
                .ReturnsAsync((BlogPost?)null);

            var service = CreateService();

            // Act
            var exists = await service.ExistsAsync(id, CancellationToken.None);

            // Assert
            Assert.False(exists);
        }
    }
}