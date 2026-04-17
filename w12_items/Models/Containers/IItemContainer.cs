using w12_items.Models.Items;

namespace w12_items.Models.Containers
{
    public interface IItemContainer
    {
        ICollection<Item> Items { get; }
        void AddItem(Item item);
        bool RemoveItem(Item item);
    }
}
