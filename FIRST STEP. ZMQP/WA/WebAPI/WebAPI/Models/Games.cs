
using Intercom.Core;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models
{
    public class GamesContext: DbContext
    {
        public DbSet<Game> Games => Set<Game>();

        public GamesContext(DbContextOptions<GamesContext> options): base(options)
        {
        }

    }

    public class Game
    {
        public string Id { get; set; } 
        public string Title { get; set; }
        public string Creator { get; set; }
    }
        
}
