using MediatR;

using Prosigliere.Challenge.Application.Dtos;

namespace Prosigliere.Challenge.Application.Commands;

public record CreateBlogPost(string Title, string Content) : IRequest<BlogPostDto>;
