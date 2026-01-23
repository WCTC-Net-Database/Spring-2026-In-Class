namespace w1_file_io
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("1. Display All Characters");
            Console.WriteLine("2. Add New Character");
            Console.WriteLine("3. Level Up Character");
            Console.WriteLine("0. Exit");

            var input = Console.ReadLine();

            if (input == "1")
            {
                Console.WriteLine("Displaying all characters...");
                var lines = File.ReadAllLines("Files/input.csv");
                //for (int i = 0; i < lines.Length; i++)
                //{
                //    Console.WriteLine($"line {i}: {lines[i]}");
                //}

                foreach (var line in lines)
                {
                    Console.WriteLine($"line: {line}");
                    var columns = line.Split(',');
                    var name = columns[0];
                    var profession = columns[1];
                    var level = columns[2];
                    var health = columns[3];
                    var equipment = columns[4];

                    Console.WriteLine($"   Name: {name}");
                    Console.WriteLine($"   Profession: {profession}");
                    Console.WriteLine($"   Level: {level}");
                    Console.WriteLine($"   Health: {health}");
                    //Console.WriteLine($"   Equipment: {equipment}");

                    var equipmentItems = equipment.Split('|');
                    Console.WriteLine("   Equipment Items:");
                    foreach (var item in equipmentItems)
                    {
                        Console.WriteLine($"      - {item}");
                    }
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
                Console.Write("Enter Equipment (separate items with | ): ");
                var equipment = Console.ReadLine();

                var newLine = $"{name},{profession},{level},{health},{equipment}";
                File.AppendAllText("Files/input.csv", newLine + Environment.NewLine);

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
                //File.WriteAllLines
            }
            else if (input == "0")
            {
                Console.WriteLine("Exiting the program...");
            }
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
