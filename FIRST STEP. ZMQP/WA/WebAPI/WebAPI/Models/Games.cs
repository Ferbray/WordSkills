
using Intercom.Core;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class GamesContext : DbContext
    {
        public DbSet<Game> Games => Set<Game>();

        public GamesContext(DbContextOptions<GamesContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Game>(entity =>
                entity.HasIndex(x => x.Title)
            );
        }

    }

    public class Game
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Creator { get; set; }
    }

}
