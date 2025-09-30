using AutoMapper;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using Prosigliere.Challenge.Domain.ValueObjects;
using Prosigliere.Challenge.Infrastructure;
using Prosigliere.Challenge.Infrastructure.Repositories;
using Prosigliere.Challenge.Infrastructure.Services;
using Prosigliere.Challenge.Infrastructure.UnitOfWork;

namespace Prosigliere.Challenge.Tests.Integrations
{
    public class BlogPostServiceIntegrationTests
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

        private static BlogPostService CreateService(AppDbContext context)
        {
            var blogPostRepo = new BlogPostRepository(context);
            var unitOfWork = new UnitOfWorkAsync(context);
            var mapper = CreateMapper();

            return new BlogPostService(blogPostRepo, mapper, unitOfWork);
        }

        [Fact]
        public async Task AddAsync_ShouldCreateBlogPost()
        {
            // Arrange
            var context = CreateDbContext();
            var service = CreateService(context);

            var creationData = new BlogPostCreationData("Integration Title", "Integration Content");

            // Act
            var created = await service.AddAsync(creationData, CancellationToken.None);

            // Assert
            Assert.NotNull(created);
            Assert.Equal(creationData.Title, created.Title);
            Assert.Equal(creationData.Content, created.Content);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnBlogPosts()
        {
            // Arrange
            var context = CreateDbContext();
            var service = CreateService(context);

            var creationData = new BlogPostCreationData("Integration Title", "Integration Content");
            await service.AddAsync(creationData, CancellationToken.None);

            // Act
            var all = (await service.GetAsync(CancellationToken.None)).ToList();

            // Assert
            Assert.Single(all);
            Assert.Equal(creationData.Title, all[0].Title);
            Assert.Equal(creationData.Content, all[0].Content);
        }

        [Fact]
        public async Task GetAsync_ById_ShouldReturnBlogPost()
        {
            // Arrange
            var context = CreateDbContext();
            var service = CreateService(context);

            var creationData = new BlogPostCreationData("Integration Title", "Integration Content");
            var created = await service.AddAsync(creationData, CancellationToken.None);

            // Act
            var result = await service.GetAsync(created.Id, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(creationData.Title, result.Title);
            Assert.Equal(creationData.Content, result.Content);
        }

        [Fact]
        public async Task ExistsAsync_ShouldReturnTrue_WhenBlogPostExists()
        {
            // Arrange
            var context = CreateDbContext();
            var service = CreateService(context);

            var creationData = new BlogPostCreationData("Integration Title", "Integration Content");
            var created = await service.AddAsync(creationData, CancellationToken.None);

            // Act
            var exists = await service.ExistsAsync(created.Id, CancellationToken.None);

            // Assert
            Assert.True(exists);
        }

        [Fact]
        public async Task ExistsAsync_ShouldReturnFalse_WhenBlogPostDoesNotExist()
        {
            // Arrange
            var context = CreateDbContext();
            var service = CreateService(context);

            // Act
            var exists = await service.ExistsAsync(Guid.NewGuid(), CancellationToken.None);

            // Assert
            Assert.False(exists);
        }
    }
}