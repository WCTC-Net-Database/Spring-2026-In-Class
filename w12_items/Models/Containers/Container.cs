using w12_items.Models.Items;

namespace w12_items.Models.Containers
{
    public abstract class Container : IItemContainer
    {
        public int Id { get; set; }

        public string ContainerType { get; set; } = string.Empty;

        public void AddItem(Item item)
        {
            item.ContainerId = Id;
            Items.Add(item);
        }

        public bool RemoveItem(Item item)
        {
            //item.ContainerId = null;
            return Items.Remove(item);
        }

        // Navigation properties
        public virtual ICollection<Item> Items { get; set; } = new List<Item>();
    }
}
