using w4_ocp.Models;

namespace w4_ocp.Data
{
    public class CsvDataSource : IDataSource
    {
        public string FilePath { get; set; } = "Files/input.csv";

        public void Write(List<Character> characters)
        {
            throw new NotImplementedException();
        }

        public List<Character> Read()
        {
            var characters = new List<Character>();

            var lines = File.ReadAllLines(FilePath);
            for (int i = 1; i < lines.Length; i++)
            {
                var parsedData = ParseLine(lines[i]);
                var character = new Character()
                {
                    Name = parsedData[0],
                    Profession = parsedData[1],
                    Level = int.Parse(parsedData[2]),
                    Health = int.Parse(parsedData[3]),
                    Equipment = parsedData[4].Split('|').ToList()
                };

                characters.Add(character);
            }

            return characters;
        }

        private string[] ParseLine(string inputLine)
        {
            string name = "";
            string profession = "";
            string level = "";
            string health = "";
            string equipment = "";

            // parse name
            if (inputLine.StartsWith("\""))
            {
                int closingQuote = inputLine.IndexOf("\"", 1);
                name = inputLine.Substring(1, closingQuote - 1);
                var restOfLine = inputLine.Substring(closingQuote + 2); // skip closing quote and comma

                var lines = restOfLine.Split(',');
                profession = lines[0];
                level = lines[1];
                health = lines[2];
                equipment = lines[3];

            }
            else
            {
                var lines = inputLine.Split(',');
                name = lines[0];
                profession = lines[1];
                level = lines[2];
                health = lines[3];
                equipment = lines[4];

            }
            return new string[] { name, profession, level, health, equipment };
        }
    }
}
