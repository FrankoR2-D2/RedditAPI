namespace RedditAPI.DTOs
{
    public class VoteDto
    {
        public Guid Id { get; set; }
        public string Type { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public Guid? PostId { get; set; }
        public Guid? CommentId { get; set; }
    }
}
