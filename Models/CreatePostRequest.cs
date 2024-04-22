using System.ComponentModel.DataAnnotations;

namespace RedditAPI.Models
{
    public class CreatePostRequest
    {
        [Required]
        public string Title { get; set; }
        public string? Content { get; set; }

        public CreatePostRequest(string title, string? content = null)
        {
            Title = title;
            Content = content;
        }
    }
}
