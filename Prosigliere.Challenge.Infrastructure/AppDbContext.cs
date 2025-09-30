using Microsoft.EntityFrameworkCore;

using Prosigliere.Challenge.Domain.Entities;
using Prosigliere.Challenge.Infrastructure.Configurations;

namespace Prosigliere.Challenge.Infrastructure;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<BlogPost> BlogPosts => Set<BlogPost>();
    public DbSet<Comment> Comments => Set<Comment>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BlogPostConfiguration());
        modelBuilder.ApplyConfiguration(new CommentConfiguration());
    }
}
