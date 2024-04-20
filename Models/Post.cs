namespace RedditAPI.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } // Reference to the User who created the post
        public DateTime CreatedAt { get; set; }
        public int VoteCount { get; set; }

        public ICollection<Comment> Comments { get; set; } // Navigation property for one-to-many relationship with Comment
    }
}
}
