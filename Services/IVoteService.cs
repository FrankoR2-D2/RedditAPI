using RedditAPI.Models;

namespace RedditAPI.Services
{
    public interface IVoteService
    {
        Task<Vote> GetVote(Guid id);
        Task<Vote> CreateVote(Vote vote);
        Task UpdateVote(Vote vote);
        Task DeleteVote(Guid id);
    }
}
