using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace RedditAPI.Models
{
    public class Post
    {
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }
        public string? Content { get; set; } // Declare 'Content' property as nullable
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        [Required]
        public string UserId { get; set; } // Post belongs to a User
        public virtual User User { get; set; } // Declare 'User' property as nullable
        public virtual ICollection<Comment>? Comments { get; set; } // Declare 'Comments' property as nullable
        public virtual ICollection<Vote>? Votes { get; set; } // Declare 'Votes' property as nullable

        public Post(string title, string userId,  string? content = null)
        {
            if (content == null)
            {
                content = title;
            }

            Title = title;
            UserId = userId;
            Content = content;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            Comments = new List<Comment>();
            Votes = new List<Vote>();
        }


    }

}

