using System.Text.Json.Serialization;

namespace w5_lsp_isp.Models
{
    public class Character
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }
        [JsonPropertyName("class")]
        public string? Profession { get; set; }
        [JsonPropertyName("level")]
        public int? Level { get; set; }
        [JsonPropertyName("hp")]
        public int? Health { get; set; }
        [JsonPropertyName("equipment")]
        public List<string> Equipment { get; set; } = new List<string>();

        public IWeapon Weapon { get; set; }

        // default constructor
        public Character() 
        { 
            //Equipment = new List<string>();
        }

        // NOT THE DEFAULT CONSTRUCTOR
        public Character(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            string equipmentList = Equipment.Count > 0
                ? string.Join(", ", Equipment)
                : "none";
            return $"{Name} the {Profession} (Level {Level}, {Health} HP) - Equipment: {equipmentList}";
        }

        //private string _hpTotal;

        //private string name;

        //public string Name
        //{
        //    get { return name; }
        //    set { name = value; }
        //}

        public void Attack(Monster monster, IWeapon weapon)
        {
            if (monster is IMagicDamageable magicDamageable)
            {
                if (weapon is IBlessedWeapon blessedWeapon)
                {
                    magicDamageable.TakeMagicDamage(blessedWeapon.HolyDamage);
                }
                else
                {
                    Console.WriteLine($"{weapon.Name} cannot deal magical damage to {monster.Name}.");
                }
            }


            if (monster is IPhysicalDamageable physicalDamageable)
            {
                physicalDamageable.TakePhysicalDamage(weapon.Damage);
            }

        }

        // Java style getters and setters
        //private string name;

        //      public void SetName(string name)
        //      {
        //          this.name = name;
        //      }
        //      public string GetName()
        //      {
        //          return name;
        //      }

    }
}
