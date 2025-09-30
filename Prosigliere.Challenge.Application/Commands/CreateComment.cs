using MediatR;

using Prosigliere.Challenge.Application.Dtos;

using System.Text.Json.Serialization;

namespace Prosigliere.Challenge.Application.Commands;

public record CreateComment([property: JsonIgnore] Guid BlogPostId, string Content) : IRequest<CommentDto>;