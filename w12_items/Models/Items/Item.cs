using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using w12_items.Models.Containers;

namespace w12_items.Models.Items
{
    public abstract class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public string ItemType { get; set; }

        public int Value { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        public decimal Weight { get; set; }

        // Navigation properties
        public int? ContainerId { get; set; }
        public virtual Container? Container { get; set; }
    }
}
