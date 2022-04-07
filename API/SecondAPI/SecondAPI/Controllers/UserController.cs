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
            if (user == null)
                return BadRequest();

            if (db.Users.Any(x => x.Id == user.Id))
                return BadRequest();

            db.Users.Add(user);
            await db.SaveChangesAsync();
            return Ok(user);
        }

        [HttpGet("{isMute}")]
        [Produces(typeof(IEnumerable<User>))]
        public async Task<IActionResult> Get([FromRoute] int isMute)
        {
            var users = await _users.Users.Where(x => x.isMute == isMute).ToListAsync();
            return Ok(users);
        }

        [HttpDelete(Name = "DeleteUser")]
        public async Task<IActionResult> Delete(int Id)
        {
            var user = await _users.Users.FirstOrDefaultAsync(x => x.Id == Id);
            if (user == null)
                return BadRequest();

            db.Users.Remove(user);
            await db.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        [Produces(typeof(IEnumerable<User>))]
        public async Task<IActionResult> Put([FromBody]UserPutModel userFromBody, [FromRoute]int id) {

            var userFromDatabase = await _users.Users.FirstOrDefaultAsync(x => x.Id == id);
            
            if (userFromDatabase == null) 
                return BadRequest();

            userFromDatabase.Id = id;
            userFromDatabase.Login = userFromBody.Login ?? userFromDatabase.Login;
            userFromDatabase.Email = userFromBody.Email ?? userFromDatabase.Email;
            userFromDatabase.isMute = userFromBody.IsMute ?? userFromDatabase.isMute;
            db.Update(userFromDatabase);
            await db.SaveChangesAsync();
            return Ok(userFromDatabase);
        }

        public class UserPutModel
        {
            public int? IsMute { get; set; }
            public string? Login { get; set; }
            public string? Email { get; set; }
        }
    }
}
