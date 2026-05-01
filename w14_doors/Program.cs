using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using w13_containers.Data;
using w13_containers.Services;

namespace w13_containers;

public class Program
{
    public static void Main(string[] args)
    {
        var serviceCollection = new ServiceCollection();
        // configure services
        Startup.ConfigureServices(serviceCollection);

        var serviceProvider = serviceCollection.BuildServiceProvider();

        // Initiating GameEngine and calling the Run() method
        var gameEngine = serviceProvider.GetService<GameEngine>();
        gameEngine?.Run();

    }

    public static class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            services.AddDbContext<GameContext>(options =>
                options
                    .UseLazyLoadingProxies()
                    .UseSqlServer(configuration.GetConnectionString("DefaultConnection"))                
                );
            services.AddTransient<GameEngine>();
        }
    }
}