using w3_srp.Models;

namespace w3_srp
{
    public class CharacterManager
    {
        private string _filePath = "Files/input.csv";
        public List<Character> Characters { get; set; } = new List<Character>();

        public CharacterManager() 
        {
        }

        public void LoadCharacters()
        {
            var lines = File.ReadAllLines(_filePath);
            for (int i = 1; i < lines.Length; i++)
            {
                var parsedData = Parser.ParseLine(lines[i]);
                var character = new Character()
                {
                    Name = parsedData[0],
                    Profession = parsedData[1],
                    Level = int.Parse(parsedData[2]),
                    Health = int.Parse(parsedData[3]),
                    Equipment = parsedData[4].Split('|').ToList()
                };
                Characters.Add(character);
            }
        }

        public void AddCharacter(Character character)
        {
            Characters.Add(character);

            // format the character data as a CSV line
            var equipmentString = string.Join("|", character.Equipment);
            var newLine = $"{character.Name},{character.Profession},{character.Level},{character.Health},{equipmentString}";

            // write the new line to the file
            File.AppendAllText(_filePath, newLine + Environment.NewLine);
        }
    }
}
