namespace w9_efcore_intro.Models
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

        // N:N
        public virtual ICollection<Item> Items { get; set; } = new List<Item>();
    }
}
