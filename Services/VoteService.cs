using Microsoft.EntityFrameworkCore;
using RedditAPI.Data;
using RedditAPI.Models;

namespace RedditAPI.Services
{
    public class VoteService : IVoteService
    {
        private readonly RedditDbContext _context;

        public VoteService(RedditDbContext context)
        {
            _context = context;
        }

        public async Task<Vote> GetVote(Guid id)
        {
            return await _context.Votes.FindAsync(id);
        }

        public async Task<Vote> CreateVote(Vote vote)
        {
            _context.Votes.Add(vote);
            await _context.SaveChangesAsync();
            return vote;
        }

        public async Task UpdateVote(Vote vote)
        {
            _context.Entry(vote).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteVote(Guid id)
        {
            var vote = await _context.Votes.FindAsync(id);
            if (vote != null)
            {
                _context.Votes.Remove(vote);
                await _context.SaveChangesAsync();
            }
        }
    }

}
