using Microsoft.EntityFrameworkCore;
using RedditAPI.Data;
using RedditAPI.Models;

namespace RedditAPI.Services
{
    public class CommentService : ICommentService
    {
        private readonly RedditDbContext _context;

        public CommentService(RedditDbContext context)
        {
            _context = context;
        }

        public async Task<Comment> GetComment(Guid id)
        {
            return await _context.Comments.FindAsync(id);
        }

        public async Task<Comment> CreateComment(Comment comment)
        {
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
            return comment;
        }

        public async Task<Comment> UpdateComment(Comment comment)
        {
            _context.Entry(comment).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return comment;
        }

        public async Task DeleteComment(Guid id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment != null)
            {
                _context.Comments.Remove(comment);
                await _context.SaveChangesAsync();
            }
        }

        public Task<IEnumerable<Comment>> GetCommentsByPostId(Guid postId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Comment>> GetCommentsByUserId(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
