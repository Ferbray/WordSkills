using Microsoft.EntityFrameworkCore;


namespace SecondAPI.Models
{

    public class UserContext : DbContext
    {
        public DbSet<User> Users => Set<User>();

        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }
    }



    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public int isAdmin { get; set; }
        public int isBan { get; set; }
        public int isMute { get; set; }

        public string? Photo { get; set; }
        public string? Description { get; set; }
    }
}
