namespace RedditAPI.Models
{
    public class PostDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UserId { get; set; } = string.Empty;
        public UserDto User { get; set; } = new UserDto();
        // Exclude the Comments and Votes properties to avoid circular references
    }
}
