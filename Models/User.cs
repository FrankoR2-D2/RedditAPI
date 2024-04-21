using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace RedditAPI.Models
{
    public class User : IdentityUser
    {
        public virtual ICollection<Post>? Posts { get; set; } // User has a collection of Posts
        public virtual ICollection<Comment>? Comments { get; set; } // User has a collection of Comments
        public virtual ICollection<Vote>? Votes { get; set; } // User has a collection of Votes
    }
}


