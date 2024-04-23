namespace RedditAPI.DTOs
{
    // Used for creating a new comment
    public class CreateCommentDto
    {
        public string Content { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public Guid PostId { get; set; }
    }
}
