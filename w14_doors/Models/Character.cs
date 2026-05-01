using w13_containers.Models.Containers;
using w13_containers.Models.Items;
using w14_doors.Models.Containers;

namespace w13_containers.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }


        // Navigation properties

        // 1:1
        public virtual CharacterStats Stats { get; set; }

        // 0..1
        public virtual Room? HomeRoom { get; set; } = null;

        public virtual int? HomeRoomId { get; set; }

        // navigation properties for inventory and equipment (1:1 relationships)

        public virtual Inventory? Inventory { get; set; }
        public int? InventoryId { get; set; }

        public virtual Equipment? Equipment { get; set; }
        public int? EquipmentId { get; set; }

        public bool PickUp(Item item)
        {
            if (Inventory == null) return false;


            Inventory.AddItem(item);
            Console.WriteLine($"{Name} picked up {item.Name}");

            return true;
        }

        public void Drop(Item item)
        {
            if (Inventory == null) return;

            if (Inventory.RemoveItem(item))
            {
                Console.WriteLine($"{Name} dropped {item.Name}");
            }
        }

        public bool EquipItem(Item item)
        {
            if (Equipment == null) return false;

            var targetSlot = Equipment.EquipmentSlots.FirstOrDefault(s => s.slotType == item.EligibleSlot);

            if (targetSlot == null)
            {
                Console.WriteLine($"You don't have an {item.EligibleSlot} available!");
                return false;
            }

            if (targetSlot.EquippedItem != null)
            {
                Console.WriteLine($"You already have an item equipped in the {item.EligibleSlot} slot!");
                return false;
            }

            if (Inventory.RemoveItem(item))
            {
                targetSlot.EquippedItem = item;
                Console.WriteLine($"{Name} equipped {item.Name} in {item.EligibleSlot} slot");
                return true;
            }

            return false;
        }
    }
}
