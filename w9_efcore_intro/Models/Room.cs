using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w9_efcore_intro.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        // Navigation properties
        // 0..1
        //public virtual Character? Character { get; set; } = null;

        // 1:N
        public virtual ICollection<Monster> Monsters { get; set; } = new List<Monster>();
    }

}
