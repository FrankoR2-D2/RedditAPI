using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedditAPI.Models;

namespace RedditAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

    }
}


/*
 * 
 * 
        // Inject your user service here

        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            // Implementation here
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            // Implementation here
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, User user)
        {
            // Implementation here
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            // Implementation here
        }
*/