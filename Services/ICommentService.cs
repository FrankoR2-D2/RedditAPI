using RedditAPI.Models;

namespace RedditAPI.Services
{
    public interface ICommentService
    {
        Task<Comment> GetComment(Guid id);
        Task<IEnumerable<Comment>> GetCommentsByPostId(Guid postId);
        Task<IEnumerable<Comment>> GetCommentsByUserId(string userId);
        Task<Comment> CreateComment(Comment comment);
        Task<Comment> UpdateComment(Comment comment);
        Task DeleteComment(Guid id);
    }
}
