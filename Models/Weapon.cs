namespace RPG_Game.Models
{
    public class Weapon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Damage { get; set; }

        public Character Character { get; set; }

        public int CharacterId { get; set; }
    }
}
