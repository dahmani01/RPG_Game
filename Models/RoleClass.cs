using System.Text.Json.Serialization;

namespace RPG_Game.Models
{
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum RoleClass
        {
            Admin = 1,
            Manager = 2,
            Client = 3,
        }
    }
