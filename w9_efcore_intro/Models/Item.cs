using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w9_efcore_intro.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation properties
        // N:N
        public virtual ICollection<Character> Characters { get; set; } = new List<Character>();
    }
}
