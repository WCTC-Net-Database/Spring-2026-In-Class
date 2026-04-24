namespace w13_containers.Models.Containers
{
    public class Equipment : Container
    {
        public virtual ICollection<EquipmentSlot> EquipmentSlots { get; set; } = new List<EquipmentSlot>();
    }
}
