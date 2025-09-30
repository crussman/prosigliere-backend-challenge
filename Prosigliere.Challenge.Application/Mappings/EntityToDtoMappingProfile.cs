
using AutoMapper;

using Prosigliere.Challenge.Application.Dtos;
using Prosigliere.Challenge.Domain.Entities;

namespace Prosigliere.Challenge.Application.Mappings;

public class EntityToDtoMappingProfile : Profile
{
    public EntityToDtoMappingProfile()
    {
        CreateMap<BlogPost, BlogPostDto>()
            .ReverseMap();

        CreateMap<Comment, CommentDto>()
            .ReverseMap();

        CreateMap<Comment, string>()
            .ConvertUsing(src => src.Content);
    }
}