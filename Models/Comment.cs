using RedditAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace RedditAPI.Models
{

    public class Comment
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        [Required]
        public int UserId { get; set; }
        public virtual User? User { get; set; }

        [Required]
        public int PostId { get; set; }
        public virtual Post? Post { get; set; }

        public virtual ICollection<Vote>? Votes { get; set; }

        public Comment(string content)
        {
            Content = content;
            UserId = GetLoggedInUserId();
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            Votes = new List<Vote>();
        }

        private int GetLoggedInUserId()
        {
            // TODO: Implement this method later
            // throw new NotImplementedException();
            return 1; // Return a default value for now
        }
    }
}
