using RedditAPI.Models;

namespace RedditAPI.Services
{
    public interface IUserService
    {
        Task<User> CreateUser(User user);
        Task<User> GetUser(int id);
        Task UpdateUser(User user);
        Task DeleteUser(int id);
    }
}
