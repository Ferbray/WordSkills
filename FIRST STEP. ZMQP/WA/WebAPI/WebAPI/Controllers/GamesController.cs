using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly GamesContext _db;
        private readonly ILogger<GamesController> _logger;

        public GamesController(ILogger<GamesController> logger, GamesContext games)
        {
            _logger = logger;
            _db = games;
        }

        
        [HttpPost()]
        public async Task<ActionResult<IEnumerable<Game>>> Post(Game game)
        {
            game.Id = Guid.NewGuid().ToString();
            if (game == null)
            {
                return BadRequest();
            }
            _db.Games.Add(game);
            await _db.SaveChangesAsync();
            return Ok();
        }
        [HttpGet(Name = "string")]
        public async Task<ActionResult<IEnumerable<Game>>> Get(string title)
        {
            var game = await _db.Games.FirstOrDefaultAsync(x => x.Title == title);
            if (game == null)
            {
                return NotFound();
            }
            return new ObjectResult(game);
        }



    }


}
