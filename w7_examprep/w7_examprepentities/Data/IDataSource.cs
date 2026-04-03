using w7_examprepentities.Models;

namespace w7_examprepentities.Data
{
    public interface IDataSource
    {
        string FilePath { get; set; }

        List<Character> Read();
        void Write(List<Character> characters);
    }
}