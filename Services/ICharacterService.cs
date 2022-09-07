using RPG_Game.Dtos.Character;

namespace RPG_Game.Services
{
    public interface ICharacterService
    {
        public Task<serviceResponse<List<GetCharacterDto>>> GetAllCharacters();
        public Task<serviceResponse<GetCharacterDto>> GetCharacterById(int id);
        public Task<serviceResponse<List<GetCharacterDto>>> AddNewCharacter(AddCharacterDto character);
        public Task<serviceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto character); 
        public Task <serviceResponse<List<GetCharacterDto>>> DeleteCharacter(int id);
    }
}
