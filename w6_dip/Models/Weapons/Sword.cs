using w6_dip.Models.Interfaces;

namespace w6_dip.Models.Weapons
{
    public class Sword : IWeapon
    {
        public string Name { get; set; }
        public int Damage { get; set; }
    }

}
