using System.ComponentModel.DataAnnotations;

namespace RedditAPI.Models
{
    public class LoginModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public LoginModel()
        {
            Email = string.Empty;
            Password = string.Empty;
        }
    }
}
