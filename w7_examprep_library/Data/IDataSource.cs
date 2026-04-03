using w7_examprep_library.Models;

namespace w7_examprep_library.Data
{
    public interface IDataSource
    {
        string FilePath { get; set; }

        List<Character> Read();
        void Write(List<Character> characters);
    }
}