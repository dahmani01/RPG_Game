using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RPG_Game.Dtos.Fight;
using RPG_Game.Services;
using RPG_Game.Services.FightService;

namespace RPG_Game.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FightController : ControllerBase
    {
        private readonly IFightService _fightService;

        public FightController(IFightService fightService)
        {
            _fightService = fightService;
        }

        [HttpPost("Weapon")]
        public async Task<ActionResult<serviceResponse<AttackResultDto>>> WeaponAttack(WeaponAttackDto request)
        {
            return Ok(await _fightService.WeaponAttack(request));

        }

        [HttpPost("Skill")]
        public async Task<ActionResult<serviceResponse<AttackResultDto>>> SkillAttack(SkillAttackDto request)
        {
            return Ok(await _fightService.SkillAttack(request));

        }

        [HttpPost("Fight")]
        public async Task<ActionResult<serviceResponse<FightResultDto>>> Fight(FightRequestDto request)
        {
            return Ok(await _fightService.Fight(request));

        }

        [HttpGet]
        public async Task<ActionResult<serviceResponse<List<HighscoreDto>>>> GetHighscore()
        {
            return Ok(await _fightService.GetHighscore());
        }

    }
}
