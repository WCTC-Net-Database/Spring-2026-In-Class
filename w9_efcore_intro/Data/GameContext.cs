using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options
                .UseLazyLoadingProxies()
                .UseSqlServer("Server=bitsql.wctc.edu;Database=w9_efcore_mmcarthey;User Id=mmcarthey;Password=000075813;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // FluentAPI configurations can go here if needed
            //modelBuilder.Entity<Character>()
            //    .HasOne(c => c.Stats)
            //    .WithOne()
            //    .HasForeignKey<CharacterStats>(cs => cs.Id);
        }
    }
}
