using Microsoft.EntityFrameworkCore;
using RedditAPI.Data;
using RedditAPI.Models;
using RedditAPI.DTOs;

namespace RedditAPI.Services
{
    public class PostService : IPostService
    {
        private readonly RedditDbContext _context;

        public PostService(RedditDbContext context)
        {
            _context = context;
        }

        public async Task<Post> CreatePost(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
            return post;
        }

        public async Task DeletePost(Guid id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post != null)
            {
                _context.Posts.Remove(post);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<PostDto> GetPost(Guid id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var comments = await _context.Comments.Where(c => c.PostId == id).ToListAsync();
            var upvotes = await _context.Votes.CountAsync(v => v.PostId == id && v.Type == "Upvote");
            var downvotes = await _context.Votes.CountAsync(v => v.PostId == id && v.Type == "Downvote");

            var postDto = new PostDto
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content ?? string.Empty,
                CreatedAt = post.CreatedAt,
                UpdatedAt = post.UpdatedAt,
                UserId = post.UserId,
                User = new UserDto
                {
                    Id = post.User!.Id,
                    UserName = post.User?.UserName ?? string.Empty,
                    Email = post.User?.Email ?? string.Empty
                },
                Comments = comments.Select(c => new CommentDto
                {
                    // Map comment fields...
                }).ToList(),
                Upvotes = upvotes,
                Downvotes = downvotes
            };

            return postDto;
        }


        public async Task<IEnumerable<Post>> GetPosts()
        {
            return await _context.Posts.ToListAsync();
        }

        public async Task<IEnumerable<Post>> GetPostsByUser(string userId)
        {
            return await _context.Posts.Where(p => p.UserId == userId).ToListAsync();
        }

        public async Task UpdatePost(Post post)
        {
            _context.Entry(post).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Post>> GetPostsByUserId(string userId)
        {
            return await _context.Posts.Where(p => p.UserId == userId).ToListAsync();
        }

    }
}
