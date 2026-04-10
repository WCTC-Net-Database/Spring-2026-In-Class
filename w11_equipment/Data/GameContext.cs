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

            modelBuilder.Entity<Room>()
                .HasOne(r => r.NorthRoom)
                .WithMany()
                //.HasForeignKey(c=> c.NorthRoomId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Room>()
                .HasOne(r => r.SouthRoom)
                .WithMany()
                //.HasForeignKey(c => c.SouthRoomId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Room>()
                .HasOne(r => r.WestRoom)
                .WithMany()
                //.HasForeignKey(c => c.WestRoomId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Room>()
                .HasOne(r => r.EastRoom)
                .WithMany()
                //.HasForeignKey(c => c.EastRoomId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
