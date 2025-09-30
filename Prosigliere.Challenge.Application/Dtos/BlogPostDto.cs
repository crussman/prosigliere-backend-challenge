namespace Prosigliere.Challenge.Application.Dtos;

public record class BlogPostDto(
    Guid Id,
    string Title,
    string Content,
    IEnumerable<string> Comments);
