namespace Prosigliere.Challenge.Domain.Entities;

public class BlogPost : BaseEntity
{
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public ICollection<Comment> Comments { get; set; } = [];
}
