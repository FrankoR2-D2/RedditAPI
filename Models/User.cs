using Microsoft.Extensions.Hosting;
using System.Xml.Linq;

namespace RedditAPI.Models
{
    public class User
    {
        public int Id { get; set; } // Assuming integer ID for simplicity
        public string Username { get; set; }
        public string PasswordHash { get; set; } // Optional, hashed password
        public DateTime CreatedAt { get; set; }

        public ICollection<Post> Posts { get; set; } // Navigation property for one-to-many relationship with Post
        public ICollection<Comment> Comments { get; set; } // Optional navigation property for one-to-many relationship with Comment (if implemented)
    }
}
