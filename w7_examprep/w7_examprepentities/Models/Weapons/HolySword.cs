using w7_examprepentities.Models.Interfaces;

namespace w7_examprepentities.Models.Weapons
{

    public class HolySword : IBlessedWeapon
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public int HolyDamage { get; set; }
    }

}
