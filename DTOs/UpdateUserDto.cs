using System.ComponentModel.DataAnnotations;

namespace RedditAPI.DTOs
{
    public class UpdateUserDto
    {
        [Required]
        public string Id { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public string? Username { get; set; }

        // If you want to allow password updates, include these:
        public string? OldPassword { get; set; }
        public string? NewPassword { get; set; }
        public string? ConfirmNewPassword { get; set; }
    }
}
