using w13_containers.Models.Containers;
using w13_containers.Models.Items;

namespace w13_containers.Models
{
    public class EquipmentSlot
    {
        public int Id { get; set; }
        public SlotType slotType { get; set; }

        public virtual Item? EquippedItem { get; set; }
        public int? EquippedItemId { get; set; }

        public virtual Equipment? Equipment { get; set; }
        public int? EquipmentId { get; set; }   
    }
}
