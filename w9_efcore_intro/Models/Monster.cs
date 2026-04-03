using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w9_efcore_intro.Models
{
    public class Monster
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation properties
        public virtual Room Room { get; set; } = new Room();
    }
}
