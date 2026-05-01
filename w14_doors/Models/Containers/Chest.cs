using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w14_doors.Models;

namespace w13_containers.Models.Containers
{
    public class Chest : Container, ILockable
    {
        public bool IsLocked { get; set; } = true;

        public string? RequiredKeyId { get; set; }
        public bool IsTrapped { get; set; }
        public bool IsPickable { get; set; }
        public bool IsSecret { get; set; }
    }
}
