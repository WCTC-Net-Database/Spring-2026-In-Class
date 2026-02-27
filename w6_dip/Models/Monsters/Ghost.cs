using w6_dip.Models.Interfaces;

namespace w6_dip.Models.Monsters
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
