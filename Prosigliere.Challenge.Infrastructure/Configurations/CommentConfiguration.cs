using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Prosigliere.Challenge.Domain.Entities;

namespace Prosigliere.Challenge.Infrastructure.Configurations;

internal class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Content).HasMaxLength(1000).IsRequired();

        builder.HasOne(p => p.BlogPost)
               .WithMany(pt => pt.Comments)
               .HasForeignKey(p => p.BlogPostId)
               .IsRequired();
    }
}
