using w13_containers.Models;
using w13_containers.Models.Containers;

namespace w14_doors.Models.Containers
{
    public class Room : Container
    {
        public string Name { get; set; }
        public string? Description { get; set; }


        // Navigation properties
        public virtual ICollection<Monster> Monsters { get; set; } = new List<Monster>();

        // exits from room

        public virtual Room? NorthRoom { get; set; }
        public virtual Room? SouthRoom { get; set; }
        public virtual Room? EastRoom { get; set; }
        public virtual Room? WestRoom { get; set; }

        // foreign key for rooms
        public int? NorthRoomId { get; set; }
        public int? SouthRoomId { get; set; }
        public int? EastRoomId { get; set; }
        public int? WestRoomId { get; set; }
    }

}
