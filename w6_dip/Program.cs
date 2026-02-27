using Microsoft.Extensions.DependencyInjection;
using w6_dip.Data;
using w6_dip.Models;
using w6_dip.Models.Interfaces;
using w6_dip.Models.Monsters;
using w6_dip.Models.Weapons;
using w6_dip.Services;

namespace w6_dip
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // add services to the container
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            // build the provider that will give us access to the services
            var serviceProvider = serviceCollection.BuildServiceProvider();

            using (var scope = serviceProvider.CreateScope())
            {
                // get the service we want to use
                var gameService = scope.ServiceProvider.GetService<GameService>();

                //IService gameService = new GameService();
                gameService?.Invoke();

            }

        }

        public static void ConfigureServices(IServiceCollection services)
        {
            // configure the scope of our services here
            services.AddTransient<GameService>();
            services.AddScoped<IDataSource, JsonDataSource>();
            services.AddTransient<CharacterManager>();

            //IDataSource dataSource = new JsonDataSource();
            //var characterManager = new CharacterManager(dataSource);

            //services.AddSingleton();
            //services.AddTransient();
            //services.AddScoped();

        }
        #region Example Code
        public static void Example()
        {
            MonsterBase ghost = new Ghost()
            { Name = "Spooky Ghost", Health = 100 };

            MonsterBase goblin = new Goblin()
            { Name = "Small Goblin", Health = 150 };

            ghost.Attack(new Character() { Name = "Hero1" });
            goblin.Attack(new Character() { Name = "Hero2" });

            ghost.TakeDamage(30);
            goblin.TakeDamage(20);

            IWeapon weapon1 = new Sword()
            { Name = "Iron Sword", Damage = 50 };

        }

        //int x = 0;
        //int? y = null;
        //Person p = null;

        //public class Person
        //{
        //    public string Name { get; set; } = string.Empty;
        //    public int Age { get; set; }
        //}


        //var character = new Character();
        //character.Name = "Aragorn";

        //if (character.Health == null)
        //{
        //    character.Health = 100;
        //}

        //var character2 = new Character()
        //{
        //    Name = "Legolas",
        //    Profession = "Archer"
        //};

        //var character = new Character("Gimli");

        //String myStr = "Hello";
        //Int32 myInt = 42;
        //Character myChar = new Character();
        //Object myObj = myChar;

        //Console.WriteLine($"Character 1: ");
        //Console.WriteLine($"\t{character.Name}");
        //Console.WriteLine($"\t{character.Profession}");
        //Console.WriteLine($"\t{character.Level}");
        //Console.WriteLine($"\t{character.Health}");

        //foreach (var item in character.Equipment)
        //{
        //    Console.WriteLine($"\t - {item}");
        //}

        //Console.WriteLine("-------------------");

        //Console.WriteLine($"Character 2: {character2}");
        #endregion

    }
}

