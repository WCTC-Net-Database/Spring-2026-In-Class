using w4_ocp.Models;

namespace w4_ocp.Data
{
    public interface IDataSource
    {
        string FilePath { get; set; }

        List<Character> Read();
        void Write(List<Character> characters);
    }
}