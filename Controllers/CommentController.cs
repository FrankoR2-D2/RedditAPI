using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedditAPI.DTOs;
using RedditAPI.Models;
using RedditAPI.Services;

namespace RedditAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;

        public CommentController(ICommentService commentService, IMapper mapper)
        {
            _commentService = commentService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CommentDto>> GetComment(Guid id)
        {
            var comment = await _commentService.GetComment(id);
            if (comment == null)
            {
                return NotFound();
            }

            var commentDto = _mapper.Map<CommentDto>(comment);

            return Ok(commentDto);
        }

        [HttpPost]
        public async Task<ActionResult<CommentDto>> CreateComment(CommentDto commentDto)
        {
            var comment = _mapper.Map<Comment>(commentDto);

            var createdComment = await _commentService.CreateComment(comment);

            var createdCommentDto = _mapper.Map<CommentDto>(createdComment);

            return CreatedAtAction(nameof(GetComment), new { id = createdCommentDto.Id }, createdCommentDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComment(Guid id, CommentDto commentDto)
        {
            if (id != commentDto.Id)
            {
                return BadRequest();
            }

            var comment = _mapper.Map<Comment>(commentDto);

            await _commentService.UpdateComment(comment);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(Guid id)
        {
            await _commentService.DeleteComment(id);
            return NoContent();
        }
    }

}
