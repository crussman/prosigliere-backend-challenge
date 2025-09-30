namespace Prosigliere.Challenge.Domain.Entities;

public class Comment : BaseEntity
{
    public string Content { get; set; } = null!;
    public Guid BlogPostId { get; set; }
    public BlogPost BlogPost { get; set; } = null!;
}
