using Microsoft.AspNetCore.Mvc;
using Auth.Services;
using Auth.Models;

namespace Auth.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly TokenService _tokenService;

        public AuthController(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] User user)
        {
            // 假設帳密正確
            if (user.Username == "admin" && user.Password == "123")
            {
                user.Role = "Admin";
                var token = _tokenService.GenerateToken(user);
                return Ok(new { token });
            }
            else if (user.Username == "user" && user.Password == "123")
            {
                user.Role = "User";
                var token = _tokenService.GenerateToken(user);
                return Ok(new { token });
            }

            return Unauthorized();
        }
    }
}
