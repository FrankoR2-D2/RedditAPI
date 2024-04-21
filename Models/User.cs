using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace RedditAPI.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public virtual ICollection<Post>? Posts { get; set; } // User has a collection of Posts
        public virtual ICollection<Comment>? Comments { get; set; } // User has a collection of Comments
        public virtual ICollection<Vote>? Votes { get; set; } // User has a collection of Votes

        public User(string username, string email, string password)
        {
            Username = username;
            Email = email;
            Password = password;
            Posts = new List<Post>();
            Comments = new List<Comment>();
            Votes = new List<Vote>();
        }
    }
}


     