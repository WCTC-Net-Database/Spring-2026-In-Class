using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using w13_containers.Models.Containers;

namespace w13_containers.Models.Items
{
    public abstract class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public string ItemType { get; set; }

        public int Value { get; set; }

        public SlotType? EligibleSlot { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        public decimal Weight { get; set; }

        // Navigation properties
        public int? ContainerId { get; set; }
        public virtual Container? Container { get; set; }
    }
}
