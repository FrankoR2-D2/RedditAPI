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
                .ForMember(dest => dest.VoteCount, opt => opt.MapFrom(src => src.Votes != null ? src.Votes.Count : 0));

            CreateMap<CommentDto, Comment>();
            CreateMap<CreateCommentDto, Comment>();


            CreateMap<Vote, VoteDto>();
            CreateMap<VoteDto, Vote>();

            CreateMap<CreateUserDto, User>();
            CreateMap<UpdateUserDto, User>();
            CreateMap<User, UserDto>();
        }
    }
}
