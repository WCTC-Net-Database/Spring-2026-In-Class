using w13_containers.Models.Items;

namespace w13_containers.Models.Containers
{
    public interface IItemContainer
    {
        ICollection<Item> Items { get; }
        void AddItem(Item item);
        bool RemoveItem(Item item);
    }
}
