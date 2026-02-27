using w6_dip.Data;
using w6_dip.Models;

namespace w6_dip
{
    public class CharacterManager
    {
        public List<Character> Characters { get; set; } = new List<Character>();
        private IDataSource _dataSource;

        public CharacterManager(IDataSource dataSource)
        {
            _dataSource = dataSource;
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
