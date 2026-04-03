using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using w9_efcore_intro.Models;

namespace w9_efcore_intro.Data
{
    public class GameContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }
        public DbSet<CharacterStats> CharacterStats { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Monster> Monsters { get; set; }

        public GameContext()
        {
        }
        public GameContext(DbContextOptions<GameContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Monster>()
                .HasDiscriminator<string>(m=>m.MonsterType)
                .HasValue<Goblin>("Goblin")
                .HasValue<Troll>("Troll");
        }

    }
}
