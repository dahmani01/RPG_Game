using RPG_Game.Services;

namespace RPG_Game.Data
{
    public interface IAuthRepository
    {
        public Task<serviceResponse<int>> Register(User user, string password);
        public Task<serviceResponse<string>> Login(string username, string password);

        public Task<bool> UserExists(string username);
    }
}
