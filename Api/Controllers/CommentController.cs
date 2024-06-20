using Api.Dtos.Comment;
using Api.Interfaces;
using Api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers

{
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepo;
        private readonly ISTockRepository _stockRepo;
        public CommentController(ICommentRepository commentRepository, ISTockRepository stockRepo)
        {
            _commentRepo = commentRepository;
            _stockRepo = stockRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var comments = await _commentRepo.GetAllAsync();

            var commentDto = comments.Select(s => s.ToCommentDto());

            return Ok(commentDto);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var comment = await _commentRepo.GetByIdAsync(id);

            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment.ToCommentDto());
        }
        [HttpPost("{stockId}")]
        public async Task<IActionResult> Create([FromRoute] int stockId, CreateCommentDto commentDto)
        {
            if(!await _stockRepo.StockExist(stockId))
            {
                return BadRequest("Stock Does not exist");
            }
            var commentModel = commentDto.ToCommentFromCreate(stockId);
            await _commentRepo.CreateAsync(commentModel);
            return CreatedAtAction(nameof(GetById), new { id = commentModel }, commentModel.ToCommentDto());
        }
    }
}
