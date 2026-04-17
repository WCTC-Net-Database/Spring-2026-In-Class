namespace w12_items.Models
{
    public class CharacterStats
    {
        public int Id { get; set; }
        public int Strength { get; set; }
        public int Intelligence { get; set; }
        public int Health { get; set; }

        // Navigation properties
        // back reference to Character 1:1
        //public virtual Character Character { get; set; }
    }
}