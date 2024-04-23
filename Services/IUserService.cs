using Microsoft.AspNetCore.Mvc;
using RedditAPI.Models;

namespace RedditAPI.Services
{
    public interface IUserService
    {
        Task<User> CreateUser(User user);
        Task<User> GetUser(string id);
        Task UpdateUser(User user);
        Task DeleteUser(string id);
        // adding get users method
        Task<IEnumerable<User>> GetUsers();
        Task<IEnumerable<Vote>> GetVotesByUser(string userId);

    }
}