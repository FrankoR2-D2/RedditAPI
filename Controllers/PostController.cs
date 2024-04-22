using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RedditAPI.Models;
using RedditAPI.Services;

namespace RedditAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IPostService _postService;

        public PostsController(UserManager<User> userManager, IPostService postService)
        {
            _userManager = userManager;
            _postService = postService;
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(Post post)
        {
            if (!ModelState.IsValid)
            {
                return View(post);
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            post.UserId = user.Id;

            // Save the post to the database...
            await _postService.CreatePost(post);

            return RedirectToAction(nameof(Index));
        }




    

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
        {
            var posts = await _postService.GetPosts();
            return Ok(posts);
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPost(Guid id)
        {
            var post = await _postService.GetPost(id);

            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePost(Guid id, Post post)
        {
            var existingPost = await _postService.GetPost(id);

            if (existingPost == null)
            {
                return NotFound();
            }

            // Update the properties of the existing post
            existingPost.Title = post.Title;
            existingPost.Content = post.Content;
            existingPost.UpdatedAt = DateTime.Now;

            await _postService.UpdatePost(existingPost);

            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(Guid id)
        {
            var post = await _postService.GetPost(id);

            if (post == null)
            {
                return NotFound();
            }

            await _postService.DeletePost(id);

            return NoContent();
        }


        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<Post>>> GetPostsByUser(string userId)
        {
            var posts = await _postService.GetPostsByUser(userId);

            if (posts == null)
            {
                return NotFound();
            }

            return Ok(posts);
        }
    }
}
