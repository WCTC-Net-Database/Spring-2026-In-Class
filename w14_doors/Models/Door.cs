using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w14_doors.Models.Containers;

namespace w14_doors.Models
{
    public class Door : ILockable
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsLocked { get; set; }
        public bool IsTrapped { get; set; }
        public bool IsPickable { get; set; }
        public bool IsSecret { get; set; }

        public string? RequiredKeyId { get; set; }

        // Navigation properties
        public virtual Room RoomA { get; set; }
        public virtual Room RoomB { get; set; }
        
        // foreign keys for rooms
        public int RoomAId { get; set; }
        public int RoomBId { get; set; }
    }
}
