using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Prosigliere.Challenge.Domain.Entities;

namespace Prosigliere.Challenge.Infrastructure.Configurations;

internal class BlogPostConfiguration : IEntityTypeConfiguration<BlogPost>
{
    public void Configure(EntityTypeBuilder<BlogPost> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Title).HasMaxLength(200).IsRequired();
        builder.Property(p => p.Content).IsRequired();

        builder.HasMany(p => p.Comments)
               .WithOne(pt => pt.BlogPost);
    }
}