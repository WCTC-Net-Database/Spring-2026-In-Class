using w4_ocp.Data;
using w4_ocp.Models;

namespace w4_ocp
{
    public class CharacterManager
    {
        public List<Character> Characters { get; set; } = new List<Character>();
        private IDataSource _dataSource;

        public CharacterManager(IDataSource genericDataSource)
        {
            //_dataSource = new JsonDataSource();
            _dataSource = genericDataSource;
        }

        public void LoadCharacters()
        {
            Characters = _dataSource.Read();
        }

        public void AddCharacter(Character character)
        {
            Characters.Add(character);
            _dataSource.Write(Characters);

            //    Characters.Add(character);

            //    // format the character data as a CSV line
            //    var equipmentString = string.Join("|", character.Equipment);
            //    var newLine = $"{character.Name},{character.Profession},{character.Level},{character.Health},{equipmentString}";

            //    // write the new line to the file
            //    File.AppendAllText(_filePath, newLine + Environment.NewLine);
            //}
        }
    }
}
