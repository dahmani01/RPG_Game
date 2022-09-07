using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RPG_Game.Data;
using RPG_Game.Dtos.User;
using RPG_Game.Services;

namespace RPG_Game.Controllers
{
    
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _auth;

        public AuthController(IAuthRepository auth)
        {
            _auth = auth;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<serviceResponse<int>>> Register(UserRegisterDto request)
        {
           var response = await _auth.Register(
               new User() { Username = request.Username },request.Password);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<serviceResponse<string>>> Login(UserLoginDto request)
        {
            var response = await _auth.Login(request.Username , request.Password);
            if (response.Success) { return Ok(response); }
            else { return BadRequest(response); }
        }

    }
}
