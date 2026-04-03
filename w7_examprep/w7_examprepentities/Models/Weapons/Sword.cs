using w7_examprepentities.Models.Interfaces;

namespace w7_examprepentities.Models.Weapons
{
    public class Sword : IWeapon
    {
        public string Name { get; set; }
        public int Damage { get; set; }
    }

}
