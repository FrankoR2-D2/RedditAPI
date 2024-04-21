using Microsoft.EntityFrameworkCore;
using RedditAPI.Data;
using RedditAPI.Models;

namespace RedditAPI.Services
{
    public class UserService : IUserService
    {
        private readonly RedditDbContext _context;

        public UserService(RedditDbContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                return user;
            }
            else
            {
                throw new ArgumentException($"User with id {id} not found.");
            }
        }

        public async Task UpdateUser(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException($"User with id {id} not found.");

            }
        }
    }
}
