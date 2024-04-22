using System.ComponentModel.DataAnnotations;

namespace RedditAPI.Models
{
    public class UserRegistrationModel
    {
        private string email = string.Empty;

        [Required]
        [EmailAddress]
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                Username = email;
            }
        }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        public string? Username { get; internal set; }

        public UserRegistrationModel()
        {
            Password = string.Empty;
            ConfirmPassword = string.Empty;
        }
    }
}
