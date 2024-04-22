using RedditAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace RedditAPI.Models
{

    public class Comment
    {
        public Guid Id { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        [Required]
        public string UserId { get; set; }
        public virtual User? User { get; set; }

        [Required]
        public Guid PostId { get; set; }
        public virtual Post? Post { get; set; }

        public virtual ICollection<Vote>? Votes { get; set; }

        public Comment(string content, string userId)
        {
            Content = content;
            UserId = userId;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            Votes = new List<Vote>();
        }

        
    }
}
