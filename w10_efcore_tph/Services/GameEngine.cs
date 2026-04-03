using Microsoft.EntityFrameworkCore;
using w9_efcore_intro.Data;
using w9_efcore_intro.Models;

namespace w9_efcore_intro.Services
{
    public class GameEngine
    {
        private readonly GameContext _context;
        public GameEngine(GameContext context)
        {
            _context = context;
        }

        public void Run()
        {
            //DisplayCharacters();
            //CreateCharacter("Hero");
            //ListRooms();
            //ListMonstersInRooms();
            //CreateMonsters();

            AddMonsterToRoom();
        }

        private void AddMonsterToRoom()
        {
            // ask the user for the Room
            foreach (var room in _context.Rooms)
            {
                Console.WriteLine($"Id: {room.Id} Room: {room.Name}");
            }

            // WILL NOT WORK because the Room is not being tracked by the context,
            // so we need to find the Room in the database first and then add the Monster to that Room
            // IF WE TRY to add a Monster with a Room that is not being tracked,
            // it will create a new Room in the database instead of associating the Monster with the existing Room
            //var room = new Room       
            //{
            //    Id = 2,
            //    Name = "Goblin's Lair"
            //};

            // OPTION 1: ask for the Room Id and then find the Room in the database
            Console.WriteLine("Enter the Id of the Room you want to add a monster to:");
            var roomChoiceId = Console.ReadLine();
            var room1 = _context.Rooms.FirstOrDefault(r => r.Id == int.Parse(roomChoiceId));

            // OPTION 2: ask for the Room name and then find the Room in the database
            //Console.WriteLine("Enter the name of the Room you want to add a monster to:");
            //var roomChoiceName = Console.ReadLine();
            //var room2 = _context.Rooms.FirstOrDefault(r => r.Name == roomChoiceName);

            _context.Monsters.Add(new Goblin
            {
                Name = "Creepy Goblin",
                Sneakiness = 5,
                Room = room1 // or room2
            });
            _context.SaveChanges();
        }

        public void ListMonstersInRooms()
        {
            var rooms = _context.Rooms.ToList();
            foreach (var room in rooms)
            {
                Console.WriteLine($"Room: {room.Name}");
                Console.WriteLine($"Description: {room.Description}");
                
                foreach (var monster in room.Monsters)
                {
                    Console.WriteLine($" - Monster: {monster.Name} (Type: {monster.MonsterType})");
                }

                Console.WriteLine();
            }
        }

        public void ListRooms()
        {
            var rooms = _context.Rooms;
            foreach (var room in rooms)
            {
                Console.WriteLine($"Room: {room.Name}");
                Console.WriteLine($"Description: {room.Description}");
                Console.WriteLine();
            }
        }

        public void CreateMonsters()
        {
            var goblin = new Goblin
            {
                Name = "Sneaky Goblin",
                Sneakiness = 7,
                Room = new Room
                {
                    Name = "Goblin's Lair",
                    Description = "A dark and damp cave filled with goblin treasures."
                }
            };
            var troll = new Troll
            {
                Name = "Strong Troll",
                Strength = 10,
                Room = new Room
                {
                    Name = "Troll's Bridge",
                    Description = "A rickety bridge guarded by a fearsome troll."
                }
            };
            _context.Monsters.Add(goblin);
            _context.Monsters.Add(troll);

            _context.SaveChanges();
        }

        private void DisplayCharacters()
        {
            var characters = _context.Characters.ToList();

            foreach (var character in characters)
            {
                Console.WriteLine($"Character: {character.Name}");

                var stats = character.Stats;
                Console.WriteLine($"Stats: STR {character.Stats.Strength}, INT {character.Stats.Intelligence}, HP {character.Stats.Health}");
            }
        }
        private void CreateCharacter(string name)
        {
            var character = new Character
            {
                Name = name,
                Stats = new CharacterStats
                {
                    Strength = 10,
                    Intelligence = 10,
                    Health = 100
                }
            };
            _context.Characters.Add(character);
            _context.SaveChanges();
        }
    }
}