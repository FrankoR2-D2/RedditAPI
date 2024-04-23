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

        public async Task<User> GetUser(string id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                throw new ArgumentException($"User with id {id} not found.");
            }
            return user;
        }


        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task UpdateUser(User user)
        {
            var userInDb = await _context.Users.FindAsync(user.Id);
            if (userInDb == null)
            {
                throw new ArgumentException($"User with id {user.Id} not found.");
            }

            // Update fields
            userInDb.UserName = user.UserName;
            userInDb.Email = user.Email;

            // The EntityState.Modified is not needed here, because the entity is being tracked
            // by the context and EF Core will detect the changes made to it.

            await _context.SaveChangesAsync();
        }

        public async Task DeleteUser(string id)
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
