using System;
using System.Collections;
using w4_ocp.Data;
using w4_ocp.Models;

namespace w4_ocp
{
    public class Program
    {
        public static void Main()
        {
            // Load characters from file at startup
            
            // ask the user for the file type (CSV or JSON)
            IDataSource dataSource = new JsonDataSource();
            var characterManager = new CharacterManager(dataSource);

            characterManager.LoadCharacters();

            // Main menu loop
            Console.WriteLine("=== RPG Character Manager ===");
            Console.WriteLine("1. Display All Characters");
            Console.WriteLine("2. Add New Character");
            Console.WriteLine("3. Level Up Character");
            Console.WriteLine("4. Search Characters");
            Console.WriteLine("0. Exit");

            var input = Console.ReadLine();

            if (input == "1")
            {
                Console.WriteLine("Displaying all characters...");

                foreach (var character in characterManager.Characters)
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
                List<string > equipment = new List<string>();
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

                characterManager.AddCharacter(character);

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

                var foundCharacters = characterManager.Characters
                    .Where(c => c.Name == nameToFind.ToLower())
                    .FirstOrDefault();

                Console.WriteLine("Searching characters...");
                Console.WriteLine(foundCharacters);

                //foreach (var character in foundCharacters)
                //{
                //    Console.WriteLine(character);
                //}

            }
            else if (input == "0")
            {
                Console.WriteLine("Exiting the program...");
            }
        }

        public static bool FindCharacter(Character character)
        {
            Console.WriteLine("Iterating");
            return character.Name == "Alice";

            //if (character.Name == "Alice")
            //{
            //    return true;
            //}

            //return false;
        }


    }
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
