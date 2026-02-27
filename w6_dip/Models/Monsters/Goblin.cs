using w6_dip.Models.Interfaces;

namespace w6_dip.Models.Monsters
{
    public class Goblin : MonsterBase, IPhysicalDamageable
    {
        public void TakePhysicalDamage(int damage)
        {
            Console.WriteLine($"{Name} takes {damage} physical damage.");
        }

        public override void Attack(Character character)
        {
            Console.WriteLine($"{Name} attacks {character.Name} with a club!");
            // Implement attack logic here
        }

        protected override void OnDamageTaken(int damage)
        {
            Console.WriteLine($"{Name} grunts in pain after taking {damage} damage.");
            // Additional behavior when the goblin takes damage
        }

        //public void TakeDamage(int damage)
        //{
        //    //base.TakeDamage(damage); // Call the base method to reduce health and print damage taken
        //    // something else happens when the goblin takes damage
        //}
    }
}
