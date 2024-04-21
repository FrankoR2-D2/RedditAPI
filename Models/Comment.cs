using RedditAPI.Models;

namespace RedditAPI.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UserId { get; set; } // Comment belongs to a User
        public virtual User User { get; set; } // Comment has a User
        public int PostId { get; set; } // Comment belongs to a Post
        public virtual Post Post { get; set; } // Comment has a Post
        public virtual ICollection<Vote> Votes { get; set; } // Comment has a collection of Votes
    }
}

