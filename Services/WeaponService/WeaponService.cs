using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using RPG_Game.Data;
using RPG_Game.Dtos.Character;
using RPG_Game.Dtos.WeaponDto;
using System.Security.Claims;

namespace RPG_Game.Services.WeaponService
{

    public class WeaponService : IWeaponService
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public WeaponService(DataContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }


        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));




        public async Task<serviceResponse<GetCharacterDto>> AddWeapon(AddWeaponDto weapon)
        {
            serviceResponse<GetCharacterDto> response = new serviceResponse<GetCharacterDto>();
            try
            {

                var Character = await _context.Characters
                    .FirstOrDefaultAsync(c => c.Id == weapon.CharacterId);


                if (Character == null)
                {
                    response.Success = false;
                    response.Message = "Character Not Found.";
                }
                else
                {
                    Weapon newWeapon = new Weapon();
                    newWeapon.Character = Character;
                    newWeapon.CharacterId = weapon.CharacterId;
                    newWeapon.Name = weapon.Name;
                    newWeapon.Damage = weapon.Damage;

                    await _context.Weapons.AddAsync(newWeapon);
                    await _context.SaveChangesAsync();
                    response.Data = _mapper.Map<GetCharacterDto>(Character);
                }

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;

        }
    }
}
