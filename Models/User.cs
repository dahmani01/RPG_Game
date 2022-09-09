using Microsoft.AspNetCore.Identity;

namespace RPG_Game.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public RoleClass Role { get; set; } = RoleClass.Client; 
        public List<Character>? Characters { get; set; } 
    }
}
