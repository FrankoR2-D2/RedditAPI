using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RedditAPI.DTOs;
using RedditAPI.Models;
using RedditAPI.Services;
using System.Text.Json;
using System.Text.Json.Serialization;

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
        public async Task<IActionResult> Create(CreatePostRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            var post = new Post(request.Title, user.Id, request.Content)
            {
                User = user
            };

            // Save the post to the database...
            await _postService.CreatePost(post);

            var postDto = new PostDto
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content!,
                CreatedAt = post.CreatedAt,
                UpdatedAt = post.UpdatedAt,
                UserId = post.UserId,
                User = new UserDto
                {
                    Id = post.User.Id,
                    UserName = post.User.UserName!,
                    Email = post.User.Email!
                }
            };

            // Serialize the postDto using the source-generated JSON serializer
            string json = JsonSerializer.Serialize(postDto);

            return Ok(json);
        }




        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostDto>>> GetPosts()
        {
            var posts = await _postService.GetPosts();

            var postDtos = posts.Select(post => new PostDto
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content!,
                CreatedAt = post.CreatedAt,
                UpdatedAt = post.UpdatedAt,
                UserId = post.UserId,
                User = new UserDto
                {
                    Id = post.User!.Id,
                    UserName = post.User.UserName!,
                    Email = post.User.Email!
                }
            }).ToList();

            return Ok(postDtos);
        }


        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<PostDto>> GetPost(Guid id)
        {
            var post = await _postService.GetPost(id);

            if (post == null)
            {
                return NotFound();
            }

            var postDto = new PostDto
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content!,
                CreatedAt = post.CreatedAt,
                UpdatedAt = post.UpdatedAt,
                UserId = post.UserId,
                User = new UserDto
                {
                    Id = post.User!.Id,
                    UserName = post.User.UserName!,
                    Email = post.User.Email!
                }
            };

            return Ok(postDto);
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
            var postDto = new PostDto
            {
                Id = existingPost.Id,
                Title = existingPost.Title,
                Content = existingPost.Content!,
                CreatedAt = existingPost.CreatedAt,
                UpdatedAt = existingPost.UpdatedAt,
                UserId = existingPost.UserId,
                User = new UserDto
                {
                    Id = existingPost.User!.Id,
                    UserName = existingPost.User.UserName!,
                    Email = existingPost.User.Email!
                }
            };

            // Serialize the postDto using the source-generated JSON serializer
            string json = JsonSerializer.Serialize(postDto);

            return Ok(json);
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

        [Authorize]
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<PostDto>>> GetPostsByUser(string userId)
        {
            var posts = await _postService.GetPostsByUser(userId);

            if (posts == null)
            {
                return NotFound();
            }

            var postDtos = posts.Select(post => new PostDto
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content!,
                CreatedAt = post.CreatedAt,
                UpdatedAt = post.UpdatedAt,
                UserId = post.UserId,
                User = new UserDto
                {
                    Id = post.User!.Id,
                    UserName = post.User.UserName!,
                    Email = post.User.Email!
                }
            }).ToList();

            return Ok(postDtos);
        }
    }


}
