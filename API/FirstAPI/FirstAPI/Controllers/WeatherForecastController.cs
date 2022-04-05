using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Concurrent;

namespace FirstAPI.Controllers
{
    [ApiController]
    [Route("api")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        public record ModelInput(string Name);


        private static ConcurrentDictionary<string, Model> _db = new();

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly AppDbContext _context;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("{id}",Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get(string id)
        {
            Console.WriteLine(id);
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost("models")]
        public async Task<IActionResult> PostAsync([FromBody] ModelInput model)
        {
            var id = Guid.NewGuid().ToString();
            var newModel = new Model(id, model.Name);
            _context.Add(newModel);
            await _context.SaveChangesAsync();
            return Ok(newModel);
        }

        [HttpGet("models")]
        public async Task<IActionResult> GetAllAsync([FromQuery] string? name)
        {
            if (name != null)
            {
                var filteredModel = await _context.Models.Where(x => x.Name.Contains(name)).ToListAsync();
                return Ok(filteredModel);
            }
            var models = await _context.Models.ToListAsync();
            return Ok(models);
        }
    }
}