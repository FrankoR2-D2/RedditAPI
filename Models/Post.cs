using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace RedditAPI.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        public string? Content { get; set; } // Declare 'Content' property as nullable
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        [Required]
        public int UserId { get; set; } // Post belongs to a User
        public virtual User? User { get; set; } // Declare 'User' property as nullable
        public virtual ICollection<Comment>? Comments { get; set; } // Declare 'Comments' property as nullable
        public virtual ICollection<Vote>? Votes { get; set; } // Declare 'Votes' property as nullable

        public Post(string title,  string? content = null)
        {
            if(content == null)
            {
                content = title;
            }

            Title = title;
            UserId = GetLoggedInUserId();
            Content = content;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            Comments = new List<Comment>();
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

