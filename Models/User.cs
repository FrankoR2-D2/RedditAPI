using Microsoft.Extensions.Hosting;
using System.Xml.Linq;

namespace RedditAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual ICollection<Post> Posts { get; set; } // User has a collection of Posts
        public virtual ICollection<Comment> Comments { get; set; } // User has a collection of Comments
        public virtual ICollection<Vote> Votes { get; set; } // User has a collection of Votes
    }
}
