using w7_examprep_library.Models.Interfaces;

namespace w7_examprep_library.Models.Weapons
{
    public class Sword : IWeapon
    {
        public string Name { get; set; }
        public int Damage { get; set; }
    }

}
