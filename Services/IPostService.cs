﻿using RedditAPI.DTOs;
using RedditAPI.Models;

namespace RedditAPI.Services
{
    public interface IPostService
    {
        Task<IEnumerable<Post>> GetPosts();
        Task<PostDto> GetPost(Guid id);
        Task<Post> CreatePost(Post post);
        Task UpdatePost(Post post);
        Task DeletePost(Guid id);
        Task<IEnumerable<Post>> GetPostsByUser(string userId);


        
    }

}
