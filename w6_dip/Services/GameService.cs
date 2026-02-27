using w6_dip.Data;
using w6_dip.Models;
using w6_dip.Models.Monsters;
using w6_dip.Models.Weapons;

namespace w6_dip.Services
{
    public class GameService : IService
    {
        private readonly CharacterManager _characterManager;
        public GameService(CharacterManager characterManager) 
        { 
            _characterManager = characterManager;
        }

        public void Invoke()
        {
            // Load characters from file at startup

            _characterManager.LoadCharacters();

            // Main menu loop
            Console.WriteLine("=== RPG Character Manager ===");
            Console.WriteLine("1. Display All Characters");
            Console.WriteLine("2. Add New Character");
            Console.WriteLine("3. Level Up Character");
            Console.WriteLine("4. Search Characters");
            Console.WriteLine("5. Attack Monster");
            Console.WriteLine("0. Exit");

            var input = Console.ReadLine();

            if (input == "1")
            {
                Console.WriteLine("Displaying all characters...");

                foreach (var character in _characterManager.Characters)
                {
                    Console.WriteLine(character);
                }

            }
            else if (input == "2")
            {
                Console.WriteLine("Adding a new character...");
                Console.Write("Enter Name: ");
                var name = Console.ReadLine();
                Console.Write("Enter Profession: ");
                var profession = Console.ReadLine();
                Console.Write("Enter Level: ");
                var level = Console.ReadLine();
                Console.Write("Enter Health: ");
                var health = Console.ReadLine();

                string userInput = "";
                List<string> equipment = new List<string>();
                Console.Write("Enter Equipment (enter 'exit' when done): ");
                do
                {
                    Console.Write("> ");
                    userInput = Console.ReadLine();

                    if (userInput != "exit")
                    {
                        equipment.Add(userInput);
                    }
                }
                while (userInput != "exit");

                var character = new Character()
                {
                    Name = name,
                    Profession = profession,
                    Level = int.Parse(level),
                    Health = int.Parse(health),
                    Equipment = equipment
                };

                _characterManager.AddCharacter(character);

                Console.WriteLine("Character Added");
            }
            else if (input == "3")
            {
                Console.WriteLine("Leveling up a character...");
                var lines = File.ReadAllLines("Files/input.csv");
                foreach (var line in lines)
                {
                    var level = line.Split(',')[2];
                }
            }
            else if (input == "4")
            {
                Console.WriteLine("Enter the character name: ");
                var nameToFind = Console.ReadLine();

                var foundCharacters = _characterManager.Characters
                    .Where(c => c.Name == nameToFind.ToLower())
                    .FirstOrDefault();

                Console.WriteLine("Searching characters...");
                Console.WriteLine(foundCharacters);

                //foreach (var character in foundCharacters)
                //{
                //    Console.WriteLine(character);
                //}

            }
            else if (input == "5")
            {
                Console.WriteLine("Attacking a monster...");

                // create a character and give a weapon to attack the monster with
                var character = _characterManager.Characters.First();
                var weapon = new Sword() { Name = "Iron Sword", Damage = 50 };
                var holyWeapon = new HolySword() { Name = "Excalibur", Damage = 70, HolyDamage = 30 };
                character.Weapon = holyWeapon;

                // create a monster to attack
                var ghost = new Ghost() { Name = "Ghost", Health = 80 };
                var goblin = new Goblin() { Name = "Goblin", Health = 100 };
                MonsterBase monster = goblin;

                character.Attack(goblin, holyWeapon);
            }
            else if (input == "0")
            {
                Console.WriteLine("Exiting the program...");
            }
        }
    }

    public interface IService
    {
        void Invoke();
    }
}
