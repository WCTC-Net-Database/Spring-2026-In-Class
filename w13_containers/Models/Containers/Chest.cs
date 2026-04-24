using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w13_containers.Models.Containers
{
    public class Chest : Container
    {
        public bool IsLocked { get; set; } = true;

        public string? RequiredKeyId { get; set; }
    }
}
