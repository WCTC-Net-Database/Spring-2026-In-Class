using w7_examprepentities.Models.Interfaces;

namespace w7_examprepentities.Models.Monsters
{
    public class Ghost : MonsterBase, IMagicDamageable
    {
        public void TakeMagicDamage(int damage)
        {
            Console.WriteLine($"{Name} takes {damage} magical damage.");
        }

        protected override void OnDamageTaken(int damage)
        {
            Console.WriteLine($"{Name} wails in surprise after taking {damage} damage.");
        }
    }
}
