using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w5_lsp_isp.Models
{
    public class Monster
    {
        public string Name { get; set; }
        public int Health { get; set; }
    }
    public interface IPhysicalDamageable
    {
        void TakePhysicalDamage(int damage);
    }

    public interface IMagicDamageable
    {
        void TakeMagicDamage(int damage);
    }

    public class Goblin : Monster, IPhysicalDamageable
    {
        public void TakePhysicalDamage(int damage)
        {
            Console.WriteLine($"{Name} takes {damage} physical damage.");
        }
    }

    public class Ghost : Monster, IMagicDamageable
    {
        public void TakeMagicDamage(int damage)
        {
            Console.WriteLine($"{Name} takes {damage} magical damage.");
        }
    }
}
