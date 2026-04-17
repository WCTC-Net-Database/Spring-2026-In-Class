using w12_items.Models.Containers;
using w12_items.Models.Items;

namespace w12_items.Models
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
    }
}
