using AutoMapper;

using Prosigliere.Challenge.Application.Commands;
using Prosigliere.Challenge.Domain.ValueObjects;

namespace Prosigliere.Challenge.Application.Mappings;

public class CommandToValueObjectMappingProfile : Profile
{
    public CommandToValueObjectMappingProfile()
    {
        CreateMap<CreateBlogPost, BlogPostCreationData>();
        CreateMap<CreateComment, CommentCreationData>();
    }
}