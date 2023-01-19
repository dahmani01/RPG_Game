using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RPG_Game.Dtos.Character;
using RPG_Game.Dtos.WeaponDto;
using RPG_Game.Services;
using RPG_Game.Services.WeaponService;

namespace RPG_Game.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeaponController : ControllerBase
    {
        private readonly IWeaponService _service;

        public WeaponController(IWeaponService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<serviceResponse<GetCharacterDto>>> AddWeapon(AddWeaponDto weapon)
        {
            return Ok(await _service.AddWeapon(weapon));
            /* var response = _service.AddWeapon(weapon);
             if (response == null)
             {
                 return BadRequest(response);
             }
             return Ok(response); */
        }
    }
}
