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
    public class VoteController : ControllerBase
    {
        private readonly IVoteService _voteService;
        private readonly IMapper _mapper;

        public VoteController(IVoteService voteService, IMapper mapper)
        {
            _voteService = voteService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VoteDto>> GetVote(Guid id)
        {
            var vote = await _voteService.GetVote(id);
            if (vote == null)
            {
                return NotFound();
            }

            var voteDto = _mapper.Map<VoteDto>(vote);

            return Ok(voteDto);
        }

        [HttpPost]
        public async Task<ActionResult<VoteDto>> CreateVote(VoteDto voteDto)
        {
            var vote = _mapper.Map<Vote>(voteDto);

            var createdVote = await _voteService.CreateVote(vote);

            var createdVoteDto = _mapper.Map<VoteDto>(createdVote);

            return CreatedAtAction(nameof(GetVote), new { id = createdVoteDto.Id }, createdVoteDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVote(Guid id, VoteDto voteDto)
        {
            if (id != voteDto.Id)
            {
                return BadRequest();
            }

            var vote = _mapper.Map<Vote>(voteDto);

            await _voteService.UpdateVote(vote);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVote(Guid id)
        {
            await _voteService.DeleteVote(id);
            return NoContent();
        }
    }

}
