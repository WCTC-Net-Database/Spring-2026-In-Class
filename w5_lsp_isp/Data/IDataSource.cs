using w5_lsp_isp.Models;

namespace w5_lsp_isp.Data
{
    public interface IDataSource
    {
        string FilePath { get; set; }

        List<Character> Read();
        void Write(List<Character> characters);
    }
}