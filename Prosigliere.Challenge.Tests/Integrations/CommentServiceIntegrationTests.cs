using AutoMapper;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using Moq;

using Prosigliere.Challenge.Domain.Entities;
using Prosigliere.Challenge.Domain.Services;
using Prosigliere.Challenge.Domain.ValueObjects;
using Prosigliere.Challenge.Infrastructure;
using Prosigliere.Challenge.Infrastructure.Repositories;
using Prosigliere.Challenge.Infrastructure.Services;
using Prosigliere.Challenge.Infrastructure.UnitOfWork;

namespace Prosigliere.Challenge.Tests.Integrations
{
    public class CommentServiceIntegrationTests
    {
        private static IMapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<Infrastructure.Mappings.EntityToValueObjectMappingProfile>();
                cfg.AddProfile<Application.Mappings.EntityToDtoMappingProfile>();
            }, LoggerFactory.Create(_ => { }));
            return config.CreateMapper();
        }

        private static AppDbContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new AppDbContext(options);
            context.SaveChanges();
            return context;
        }

        private static CommentService CreateService(AppDbContext context, IBlogPostService blogPostService)
        {
            var commentRepo = new CommentRepository(context);
            var unitOfWork = new UnitOfWorkAsync(context);
            var mapper = CreateMapper();

            return new CommentService(commentRepo, mapper, unitOfWork);
        }

        [Fact]
        public async Task AddAsync_ShouldCreateComment()
        {
            // Arrange
            var context = CreateDbContext();
            var blogPost = new BlogPost { Id = Guid.NewGuid(), Title = "Post", Content = "Content" };
            context.BlogPosts.Add(blogPost);
            context.SaveChanges();

            var blogPostServiceMock = new Mock<IBlogPostService>();
            blogPostServiceMock.Setup(s => s.ExistsAsync(blogPost.Id, It.IsAny<CancellationToken>())).ReturnsAsync(true);

            var service = CreateService(context, blogPostServiceMock.Object);

            var creationData = new CommentCreationData(blogPost.Id, "Test comment");

            // Act
            var created = await service.AddAsync(creationData, CancellationToken.None);

            // Assert
            Assert.NotNull(created);
            Assert.Equal(creationData.Content, created.Content);
            Assert.Equal(creationData.BlogPostId, created.BlogPostId);
        }
    }
}