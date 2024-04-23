namespace RedditAPI.DTOs
{
    public class CommentDto
    {
        public Guid Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UserId { get; set; } = string.Empty;
        public Guid PostId { get; set; }
        public int VoteCount { get; set; }  // You might want to include the vote count in the DTO
    }
}
