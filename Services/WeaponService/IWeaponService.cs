using RPG_Game.Dtos.Character;
using RPG_Game.Dtos.WeaponDto;

namespace RPG_Game.Services.WeaponService
{
    public interface IWeaponService
    {
        public Task<serviceResponse<GetCharacterDto>> AddWeapon(AddWeaponDto weapon);
    }
}
