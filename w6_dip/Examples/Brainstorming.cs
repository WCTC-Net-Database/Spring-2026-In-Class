namespace w5_lsp_isp.Examples
{
    public interface IAttackable { }
    public interface IOpenable { }
    public interface IBreakable
    {
        void Break();
    }
    public interface IPickable { }
    public interface IDroppable { }
    public interface ITrappable { }

    public class Monster : IAttackable
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public void Attack()
        {
            Console.WriteLine($"{Name} attacks the player!");
        }

    }

    public class Room
    {
        public string Name { get; set; }
        public Monster? Monster { get; set; }
    }

    public interface IMonster
    {
        void Attack();
        void Move();
    }

    public class Item
    {
        public string Name { get; set; }

    }

    // I'm trying to create this to have a list of different types of chests that can be in rooms
    public class Chest : Item, IOpenable, IBreakable
    {
        public void Open()
        {
            Console.WriteLine($"You open the {Name} chest.");
        }
        public void Break()
        {
            Console.WriteLine($"You break the {Name} chest.");
        }
    }

    public class TrappedChest : Chest, ITrappable
    {
        public void TriggerTrap()
        {
            Console.WriteLine($"You triggered the trap in the {Name} chest!");
        }
    }

    public class Potion : Item, IOpenable, IBreakable, IDroppable
    {
        public void Open()
        {
            Console.WriteLine($"You open the {Name} potion.");
        }
        public void Break()
        {
            Console.WriteLine($"You break the {Name} potion.");
        }
        public void Drop()
        {
            Console.WriteLine($"You drop the {Name} potion.");
        }
    }

    public class Staff : Item, IBreakable
    {
        public void Break()
        {
            Console.WriteLine($"You broke {Name}!");
        }
    }


    public class Goblin : Monster
    {
        public Goblin()
        {
            Name = "Goblin";
            Health = 10;
        }
        public void Sneak()
        {
            Console.WriteLine($"{Name} sneaks past the player!");
        }

        public int Stealth { get; set; }
    }

    public class Ghost : Monster
    {
        public Ghost()
        {
            Name = "Ghost";
            Health = 20;
            Transparency = 0.80f;
        }
        public float Transparency { get; set; }
    }
}
