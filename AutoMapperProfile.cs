using AutoMapper;
using RPG_Game.Dtos.Character;
using RPG_Game.Dtos.Fight;
using RPG_Game.Dtos.Skill;
using RPG_Game.Dtos.WeaponDto;

namespace RPG_Game
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDto>();
            CreateMap<AddCharacterDto, Character>();
            CreateMap<AddWeaponDto, Weapon>();
            CreateMap<Weapon, GetWeaponDto>();
            CreateMap<Skill, GetSkillDto>();
            CreateMap<Character, HighscoreDto>();
        }
    }
}
