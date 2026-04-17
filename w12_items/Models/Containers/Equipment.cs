namespace w12_items.Models.Containers
{
    public class Equipment : Container
    {

    }

    public class EquipmentSlot
    {
        public int Id { get; set; }
        public SlotType slotType { get; set; }
    }

        public enum SlotType
        {
            Head,
            Body,
            Legs,
            Feet,
            Hands,
            Weapon,
            Shield,
            Accessory
    }   
}
