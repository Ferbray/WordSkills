using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecondAPI.Models;

namespace SecondAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private UserContext db;

        private readonly ILogger<UserController> _logger;
        private readonly UserContext _users;


        public UserController(ILogger<UserController> logger, UserContext users, UserContext context)
        {
            _logger = logger;
            _users = users;
            db = context;
        }

        [HttpPost(Name = "PostUser")]
        public async Task<IActionResult> Post(User user)
        {
            db.Users.Add(user);
            await db.SaveChangesAsync();
            return Ok(user);
        }

        [HttpGet(Name = "GetUsers")]
        [Produces(typeof(IEnumerable<User>))]
        public async Task<IActionResult> Get()
        {
            var users = await _users.Users.ToListAsync();
            return Ok(users);
        }
    }
}
