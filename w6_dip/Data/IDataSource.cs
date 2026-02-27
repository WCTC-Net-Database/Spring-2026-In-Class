using w6_dip.Models;

namespace w6_dip.Data
{
    public interface IDataSource
    {
        string FilePath { get; set; }

        List<Character> Read();
        void Write(List<Character> characters);
    }
}