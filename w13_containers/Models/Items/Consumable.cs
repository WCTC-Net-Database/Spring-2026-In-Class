namespace w13_containers.Models.Items
{
    public class Consumable : Item
    {
        public string EffectType { get; set; } = "Heal";
        public int EffectAmount { get; set; }
        public int Uses { get; set; } = 1;
    }
}
