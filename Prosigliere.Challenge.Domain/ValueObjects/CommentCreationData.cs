namespace Prosigliere.Challenge.Domain.ValueObjects;

public record CommentCreationData(Guid BlogPostId, string Content);