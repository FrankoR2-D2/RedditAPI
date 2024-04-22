using RedditAPI.Models;

namespace RedditAPI.Models
{
    public class Vote
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string UserId { get; set; }
        public virtual User? User { get; set; }
        public Guid? PostId { get; set; }
        public virtual Post? Post { get; set; }
        public Guid? CommentId { get; set; }
        public virtual Comment? Comment { get; set; }

        public Vote(string userId, string type, Guid? postId = null, Guid? commentId = null)
        {
            UserId = userId;
            Type = type;
            PostId = postId;
            CommentId = commentId;
        }

    }
}


