using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RedditAPI.Models;

namespace RedditAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : Controller
    {
        private readonly UserManager<User> _userManager;

        public PostsController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Create(Post post)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user != null)
                {
                    Guid guid;
                    if (Guid.TryParse(user.Id, out guid))
                    {
                        post.UserId = guid.ToString();
                    }
                    else
                    {
                        // Log an error, return an error response, or throw an exception
                        ModelState.AddModelError("", "User ID is not a valid GUID.");
                        return View(post);
                    }
                }
                else
                {
                    // Log an error, return an error response, or throw an exception
                    ModelState.AddModelError("", "User not found.");
                    return View(post);
                }

                

                // Save the post to the database...

                return RedirectToAction(nameof(Index));
            }

            return View(post);
        }
    }
}
