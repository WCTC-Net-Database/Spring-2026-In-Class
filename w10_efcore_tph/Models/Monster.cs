namespace w9_efcore_intro.Models
{
    public abstract class Monster
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public abstract string MonsterType { get; set; }

        // Navigation properties
        public virtual Room Room { get; set; } = new Room();
    }

    public class Goblin : Monster
    {
        public override string MonsterType { get => "Goblin"; set { }  }

        public int Sneakiness { get; set; }

    }

    public class Troll : Monster
    {
        public override string MonsterType { get => "Troll"; set{ } }
        public int Strength { get; set; }
    }
}
