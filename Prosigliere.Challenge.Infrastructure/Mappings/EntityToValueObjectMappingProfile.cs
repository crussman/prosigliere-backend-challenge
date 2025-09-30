using AutoMapper;

using Prosigliere.Challenge.Domain.Entities;
using Prosigliere.Challenge.Domain.ValueObjects;

namespace Prosigliere.Challenge.Infrastructure.Mappings;

public class EntityToValueObjectMappingProfile : Profile
{
    public EntityToValueObjectMappingProfile()
    {
        CreateMap<BlogPost, BlogPostCreationData>().ReverseMap();
        CreateMap<Comment, CommentCreationData>().ReverseMap();
    }
}