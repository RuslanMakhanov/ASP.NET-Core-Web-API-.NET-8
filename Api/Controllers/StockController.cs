using Api.Data;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;
        public StockController(ApplicationDBContext context)
        {
            _dbContext = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var stocks = _dbContext.Stocks.ToList();

            return Ok(stocks);
        }
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var stock = _dbContext.Stocks.Find(id);
            if (stock == null) 
            {
                return NotFound();
            }
            return Ok(stock);
        }
        
    }
}
