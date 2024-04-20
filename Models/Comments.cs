namespace RedditAPI.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; } // Reference to the Post the comment belongs to
        public int? UserId { get; set; } // Optional user ID for commenting (can be null)
        public User User { get; set; } // Optional reference to the User who created the comment (if implemented)
        public DateTime CreatedAt { get; set; }
        public int VoteCount { get; set; }
    }
}
