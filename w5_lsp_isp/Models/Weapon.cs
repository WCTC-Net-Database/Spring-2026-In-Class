using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w5_lsp_isp.Models
{
    public interface IWeapon
    {
        string Name { get; set; }
        int Damage { get; set; }

        //void DealDamage();
    }

    public interface IBlessedWeapon : IWeapon
    {
        int HolyDamage { get; set; }
    }

    public class Sword : IWeapon
    {
        public string Name { get; set; }
        public int Damage { get; set; }
    }

    public class HolySword : IBlessedWeapon
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public int HolyDamage { get; set; }
    }

}
