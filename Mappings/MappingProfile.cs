using AutoMapper;
using RedditAPI.DTOs;
using RedditAPI.Models;

namespace RedditAPI.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Comment, CommentDto>()
                .ForMember(dest => dest.VoteCount, opt => opt.MapFrom(src => src.Votes.Count));
            CreateMap<CommentDto, Comment>();

            CreateMap<Vote, VoteDto>();
            CreateMap<VoteDto, Vote>();
        }
    }
}
