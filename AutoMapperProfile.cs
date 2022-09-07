using AutoMapper;
using RPG_Game.Dtos.Character;

namespace RPG_Game
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDto>();
            CreateMap<AddCharacterDto,Character>();
        }
    }
}
