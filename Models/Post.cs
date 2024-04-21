namespace RedditAPI.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UserId { get; set; } // Post belongs to a User
        public virtual User User { get; set; } // Post has a User
        public virtual ICollection<Comment> Comments { get; set; } // Post has a collection of Comments
        public virtual ICollection<Vote> Votes { get; set; } // Post has a collection of Votes
    }


}

