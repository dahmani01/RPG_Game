using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RPG_Game.Data;
using RPG_Game.Dtos.Character;
using System.Security.Claims;
using System.Security.Cryptography;

namespace RPG_Game.Services
{
    public class CharacterService : ICharacterService
    {
       
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CharacterService(IMapper mapper , DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
        public async Task<serviceResponse<List<GetCharacterDto>>> AddNewCharacter(AddCharacterDto NewCharacter)
        {
            var serviceResponse = new serviceResponse<List<GetCharacterDto>>();
            Character character = _mapper.Map<Character>(NewCharacter);
            character.User = await _context.Users.FirstOrDefaultAsync(u => u.Id == GetUserId());
            _context.Characters.Add(character);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _context.Characters
                .Where(c => c.User.Id == GetUserId())
                .Select(c => _mapper.Map<GetCharacterDto>(c))
                .ToList();
            return serviceResponse;
        }

        public async Task<serviceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
            var serviceResponse = new serviceResponse<List<GetCharacterDto>>();
            try
            {
                var character = await _context.Characters.FirstAsync(c => c.Id == id && c.User.Id == GetUserId());
               
                _context.Characters.Remove(character);
                    await _context.SaveChangesAsync(); 
                serviceResponse.Data = _context.Characters
                        .Where(c => c.User.Id == GetUserId())
                        .Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
               
            }
            catch ( Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Character not found !";
            }
            
            return serviceResponse;
        }

        public async Task<serviceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            var response = new serviceResponse<List<GetCharacterDto>>() ;
            var DbCharcters = await _context.Characters
                .Where(c => c.User.Id == GetUserId())
                .ToListAsync();
            response.Data = DbCharcters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();

            return response; 
        }

        public async Task<serviceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            var serviceResponse = new serviceResponse<GetCharacterDto>();
            try
            {
                
                var character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id && c.User.Id == GetUserId());
                serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message; 
            }
            return serviceResponse;
        }

        public async Task<serviceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto UpdateCharacter)
        {
            var serviceResponse = new serviceResponse<GetCharacterDto>();
            try
            {
                var character = await _context.Characters
                    .Include(c => c.User)
                    .FirstOrDefaultAsync(c => c.Id == UpdateCharacter.Id);

                if (character.User.Id == GetUserId())
                {
                    character.Strength = UpdateCharacter.Strength;
                    character.Defense = UpdateCharacter.Defense;
                    character.Name = UpdateCharacter.Name;
                    character.Class = UpdateCharacter.Class;
                    character.Intelligence = UpdateCharacter.Intelligence;
                    character.HitPoints = UpdateCharacter.HitPoints;
                    character.Id = UpdateCharacter.Id;
                    await _context.SaveChangesAsync();

                    serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);

                }
                else
                {
                    serviceResponse.Success=false;
                    serviceResponse.Message = "Character not found !"; 
                }

            }
            catch (NullReferenceException ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
                        return serviceResponse; 
        }
    }
}
