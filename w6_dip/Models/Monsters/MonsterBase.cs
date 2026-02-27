namespace w6_dip.Models.Monsters
{

    public abstract class MonsterBase
    {
        public string Name { get; set; }
        public int Health { get; set; }

        // default method - CAN BE overidden by derived classes
        public virtual void Attack(Character character)
        {
            Console.WriteLine($"{Name} attacks {character.Name}!");
            // Implement attack logic here
        }

        // MUST BE overridden by derived classes
        // similar to an interface method
        protected abstract void OnDamageTaken(int damage);

        // Template method pattern:
        // Define a method that calls another method that can be overridden by derived classes
        public void TakeDamage(int damage)
        {
            Health -= damage;

            OnDamageTaken(damage); // Call the method that can be overridden by derived classes

            Console.WriteLine($"{Name} takes {damage} damage! Remaining health: {Health}");
        }

        public override string ToString()
        {
            return $"{Name} (Health: {Health})";
        }
    }
}
