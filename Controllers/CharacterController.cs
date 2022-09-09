using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RPG_Game.Dtos.Character;
using RPG_Game.Services;
using System.Security.Claims;

namespace RPG_Game.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        
        [HttpGet("GetAllCharacters")]
        public async Task<ActionResult<serviceResponse<List<GetCharacterDto>>>> GetAllCharacters()
        { 
            return Ok(await _characterService.GetAllCharacters());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<serviceResponse<GetCharacterDto>>> Get(int id)
        {
            var response = await _characterService.GetCharacterById(id);
            if (response.Data == null)
                return NotFound(response);
            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        [Authorize(Roles = "Manager")]
        [HttpPost("AddNewCharacter")]
        public async Task<ActionResult<serviceResponse<List<GetCharacterDto>>>> AddNewCharacter(AddCharacterDto character)
        {
            return Ok(await _characterService.AddNewCharacter(character));
        }

        [Authorize(Roles = "Admin,Manager")]
        [HttpPut("UpdateCharacter")]
        public async Task<ActionResult<serviceResponse<GetCharacterDto>>> UpdateCharacter(UpdateCharacterDto character)
        {
            var serviceResponse = await _characterService.UpdateCharacter(character);
            if (serviceResponse.Data != null)
            return Ok(serviceResponse);
            return NotFound(serviceResponse);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("DeleteCharacter")]
        public async Task<ActionResult<serviceResponse<List<GetCharacterDto>>>> DeleteCharacter(int id)
        {
            var serviceResponse = await _characterService.DeleteCharacter(id);
            if (serviceResponse.Data != null)
                return Ok(serviceResponse);
            return NotFound(serviceResponse); 
        }
    }
}
