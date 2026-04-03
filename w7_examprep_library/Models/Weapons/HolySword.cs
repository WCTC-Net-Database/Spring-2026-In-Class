using w7_examprep_library.Models.Interfaces;

namespace w7_examprep_library.Models.Weapons
{

    public class HolySword : IBlessedWeapon
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public int HolyDamage { get; set; }
    }

}
