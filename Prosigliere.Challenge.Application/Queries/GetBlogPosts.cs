using MediatR;

using Prosigliere.Challenge.Application.Dtos;

namespace Prosigliere.Challenge.Application.Queries;

public record GetBlogPosts() : IRequest<IEnumerable<BlogPostDto>>;
