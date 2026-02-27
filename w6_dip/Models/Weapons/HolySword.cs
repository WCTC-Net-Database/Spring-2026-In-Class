using w6_dip.Models.Interfaces;

namespace w6_dip.Models.Weapons
{

    public class HolySword : IBlessedWeapon
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public int HolyDamage { get; set; }
    }

}
