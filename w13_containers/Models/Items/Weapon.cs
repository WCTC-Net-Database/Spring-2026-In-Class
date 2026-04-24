namespace w13_containers.Models.Items
{
    public class Weapon : Item
    {
        public int Attack { get; set; }

        public int GetAttackRating()
        {
            // For simplicity, let's say the attack rating is just the Attack value.
            // In a real game, this could be more complex and involve character stats, weapon rarity, etc.
            return Attack;
        }
    }
}
