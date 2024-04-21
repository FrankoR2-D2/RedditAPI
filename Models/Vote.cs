namespace RedditAPI.Models
{
    public class Vote
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int UserId { get; set; } // Vote belongs to a User
        public virtual User User { get; set; } // Vote has a User
        public int? PostId { get; set; } // Vote belongs to a Post (nullable)
        public virtual Post Post { get; set; } // Vote has a Post
        public int? CommentId { get; set; } // Vote belongs to a Comment (nullable)
        public virtual Comment Comment { get; set; } // Vote has a Comment
    }
}
