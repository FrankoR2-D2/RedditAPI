using System.ComponentModel.DataAnnotations;

namespace RedditAPI.Models
{
    public class UserRegistrationModel
    {


        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public string? Username { get; internal set; }

        public UserRegistrationModel()
        {
            Email = string.Empty;
            Password = string.Empty;
            ConfirmPassword = string.Empty;
            Username = string.Empty;

        }
    }
}
