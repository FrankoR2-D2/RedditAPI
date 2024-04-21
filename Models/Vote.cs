using RedditAPI.Models;

namespace RedditAPI.Models
{
    public class Vote
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int UserId { get; set; }
        public virtual User? User { get; set; }
        public int? PostId { get; set; }
        public virtual Post? Post { get; set; }
        public int? CommentId { get; set; }
        public virtual Comment? Comment { get; set; }

        public Vote(int userId, string type, int? postId = null, int? commentId = null)
        {
            UserId = GetLoggedInUserId();
            Type = type;
            PostId = postId;
            CommentId = commentId;
        }


        private int GetLoggedInUserId()
        {
            // TODO: Implement this method later
            // throw new NotImplementedException();
            return 1; // Return a default value for now
        }
    }
}


