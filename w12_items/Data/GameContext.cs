using Microsoft.EntityFrameworkCore;
using w12_items.Models;
using w12_items.Models.Containers;
using w12_items.Models.Items;

namespace w12_items.Data
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

            // =============================================
            // W12: Configure TPH for Items and Containers
            // =============================================
            modelBuilder.Entity<Item>()
                .HasDiscriminator(i => i.ItemType)
                .HasValue<Weapon>(nameof(Weapon))
                .HasValue<Armor>(nameof(Armor))
                .HasValue<KeyItem>(nameof(KeyItem))
                .HasValue<Consumable>(nameof(Consumable));

            modelBuilder.Entity<Container>()
                .HasDiscriminator(c => c.ContainerType)
                .HasValue<Inventory>(nameof(Inventory))
                .HasValue<Equipment>(nameof(Equipment));

            modelBuilder.Entity<Item>()
                .HasOne(i => i.Container)
                .WithMany(c => c.Items)
                .HasForeignKey(i => i.ContainerId)
                .OnDelete(DeleteBehavior.SetNull);

            // =============================================
            // Previous classes
            // =============================================
            modelBuilder.Entity<Monster>()
                .HasDiscriminator(m=>m.MonsterType)
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
