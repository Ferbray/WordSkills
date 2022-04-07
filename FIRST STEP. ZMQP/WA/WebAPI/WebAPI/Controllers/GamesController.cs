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

        
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Game>>> Post(Game game)
        {
            if (game == null)
            {
                return BadRequest();
            }
            _db.Games.Add(game);
            await _db.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<IEnumerable<Game>>> Put([FromBody]Game game, [FromRoute]int id)
        {
            var game1 = await _db.Games.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (game1 == null)
            {
                return NotFound();
            }
            game.Id = id;
            _db.Update(game);
            await _db.SaveChangesAsync();
            return Ok(game);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<Game>>> Delete(int id)
        {
            var game1 = await _db.Games.FirstOrDefaultAsync(x => x.Id == id);
            if (game1 == null) return NotFound();
            _db.Games.Remove(game1);
            await _db.SaveChangesAsync();
            return Ok();
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<Game>>> Get(string title)
        {
            var game = await _db.Games.FirstOrDefaultAsync(x => x.Title == title);
            if (game == null)
            {
                return NotFound();
            }
            return new ObjectResult(game);
        }
        
        [HttpGet("{creator}")]

        public async Task<ActionResult<IEnumerable<Game>>> GetByCreator(string creator)
        {
            var gameCreators = await _db.Games.Where(x => x.Creator == creator).ToListAsync();

            return Ok(gameCreators);

        }

        



    }


}
