using RedditAPI.Data;
using RedditAPI.Models;

namespace RedditAPI.Services
{
    public class PostService : IPostService
    {
        private readonly RedditDbContext _context;

        public PostService(RedditDbContext context)
        {
            _context = context;
        }

        public Task<Post> CreatePost(Post post)
        {
            throw new NotImplementedException();
        }

        public Task DeletePost(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Post> GetPost(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Post>> GetPosts()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Post>> GetPostsByUser(string userId)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePost(Post post)
        {
            throw new NotImplementedException();
        }

        // Implement the methods here
    }
}
