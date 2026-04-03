using System.Text.Json;
using w7_examprep_library.Models;

namespace w7_examprep_library.Data
{
    public class JsonDataSource : IDataSource
    {
        public string FilePath { get; set; } = "Files/input.json";

        public List<Character> Read()
        {
            var json = File.ReadAllText(FilePath);
            var characters = JsonSerializer.Deserialize<List<Character>>(json);
            return characters;
        }

        public void Write(List<Character> characters)
        {
            var json = JsonSerializer.Serialize(characters, new JsonSerializerOptions
            {
                WriteIndented = true
            } );
            File.WriteAllText(FilePath, json);
        }
    }
}
