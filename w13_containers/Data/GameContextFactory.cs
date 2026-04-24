using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace w13_containers.Data
{
    public class GameContextFactory : IDesignTimeDbContextFactory<GameContext>
    {
        public GameContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<GameContext>();
            optionsBuilder.UseSqlServer(connectionString);
            
            return new GameContext(optionsBuilder.Options);
        }
    }
}
