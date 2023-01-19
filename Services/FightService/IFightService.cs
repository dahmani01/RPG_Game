using RPG_Game.Dtos.Fight;

namespace RPG_Game.Services.FightService
{
    public interface IFightService
    {
        public Task<serviceResponse<AttackResultDto>> WeaponAttack(WeaponAttackDto request);
        public Task<serviceResponse<AttackResultDto>> SkillAttack(SkillAttackDto request);

        public Task<serviceResponse<FightResultDto>> Fight(FightRequestDto request);
        public Task<serviceResponse<List<HighscoreDto>>> GetHighscore();
    }
}
