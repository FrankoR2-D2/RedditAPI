using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RedditAPI.DTOs;
using RedditAPI.Models;
using RedditAPI.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RedditAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IVoteService _voteService;
        private readonly IPostService _postService;

        public UserController(IUserService userService, UserManager<User> userManager, IConfiguration configuration, IMapper mapper, IVoteService voteService, IPostService postService)
        {
            _userManager = userManager;
            _userService = userService;
            _configuration = configuration;
            _mapper = mapper;
            _voteService = voteService;
            _postService = postService;
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateUser(CreateUserDto createUserDto)
        {
            var user = _mapper.Map<User>(createUserDto);
            var newUser = await _userService.CreateUser(user);
            var newUserDto = _mapper.Map<UserDto>(newUser);
            return CreatedAtAction(nameof(GetUser), new { id = newUserDto.Id }, newUserDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUser(string id)
        {
            var user = await _userService.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            var userDto = _mapper.Map<UserDto>(user);
            return userDto;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, UpdateUserDto updateUserDto)
        {
            if (id != updateUserDto.Id)
            {
                return BadRequest();
            }
            var user = _mapper.Map<User>(updateUserDto);
            await _userService.UpdateUser(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            await _userService.DeleteUser(id);
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            var users = await _userService.GetUsers();
            var userDtos = _mapper.Map<IEnumerable<UserDto>>(users);
            return Ok(userDtos);
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var token = GenerateToken(user);
                return Ok(new { token });
            }

            return Unauthorized();
        }


        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserRegistrationModel model)
        {
            var existingUser = await _userManager.FindByEmailAsync(model.Email);
            if (existingUser != null)
            {
                return BadRequest("Email is already taken.");
            }
            var user = new User { UserName = string.IsNullOrEmpty(model.Username) ? model.Email : model.Username, Email = model.Email };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
            }

            return BadRequest(result.Errors);
        }


        private string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtKey = _configuration["Jwt:Key"] ?? throw new Exception("JWT Key not found in configuration");
            var key = Encoding.ASCII.GetBytes(jwtKey);


            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.NameIdentifier, user.Id) }),

                //Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Audience = _configuration["Jwt:Audience"],
                Issuer = _configuration["Jwt:Issuer"]
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


        [Authorize]
        [HttpGet("{userId}/votes")]
        public async Task<ActionResult<IEnumerable<PostDto>>> GetUserVotes(string userId)
        {
            // Get all votes made by the user
            var votes = await _voteService.GetVotesByUser(userId);

            if (votes == null)
            {
                return NotFound();
            }

            // Get the posts associated with each vote
            var postDtos = new List<PostDto>();
            foreach (var vote in votes)
            {
                if (vote.PostId == null)
                {
                    continue;
                }

                var post = await _postService.GetPost(vote.PostId.Value);
                if (post != null)
                {
                    postDtos.Add(new PostDto
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
                    });
                }
            }

            return Ok(postDtos);
        }



    }
}

